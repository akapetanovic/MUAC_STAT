using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Timers;
using System.Xml;
using PenetrationPoints;


namespace MUAC_STAT
{
    public static class TriggerFileHandler
    {
        private static bool ProcessingEnabled = true;
        private static StreamReader MyStreamReader;
        private static System.Timers.Timer System_Status_Timer;

        public static void EnableProcessing(bool enable)
        {
            ProcessingEnabled = enable;
        }
        public static void Initialise()
        {
            // Now start heart beat timer.
            System_Status_Timer = new System.Timers.Timer(5000); // Set up the timer for 5 sec
            System_Status_Timer.Elapsed += new ElapsedEventHandler(System_Status_Periodic_Update);
            System_Status_Timer.Enabled = true;
        }

        // Periodically call System Status Handler
        private static void System_Status_Periodic_Update(object sender, ElapsedEventArgs e)
        {
            if (ProcessingEnabled)
            {
                DateTime Now = DateTime.Now;
                System_Status_Timer.Enabled = false;
                Handle_New_File();
                System_Status_Timer.Enabled = true;
            }
        }

        public static void Handle_New_File()
        {
            try
            {
                // Lets first extract location of the directory with the data of the flight to be analised
                string Data_Location_File = Properties.Settings.Default.TriggerLocation + "\\data_location.txt";
                // Check if the data location file exists
                if (System.IO.File.Exists(Data_Location_File))
                {
                    // Yes we found it, so lets parse it and extract all flight data locations
                    string[] Flights_To_Analyse_Locations = Extract_Paths_To_Each_Flight_To_Be_Analysed(Data_Location_File);

                    // There are some data for this flight, so lets extract it
                    if (Flights_To_Analyse_Locations.Length > 0)
                    {
                        // Lets first try to extract the general data from the MAIN direct
                        foreach (string File_Path in Flights_To_Analyse_Locations)
                        {
                            // Lets first try to extract the general data from the MAIN directory
                            string[] File_To_Look_For = Directory.GetFiles(File_Path + "\\MAIN", "MAIN_Closure*.xml", SearchOption.TopDirectoryOnly);

                            if (File_To_Look_For.Length > 0)
                            {
                                try
                                {
                                    using (MyStreamReader = System.IO.File.OpenText(File_To_Look_For[0]))
                                    {
                                        if (MyStreamReader != null)
                                        {
                                            GeneralDataSet DataSet = new GeneralDataSet();
                                            if (DataSet.Populate_General_Data(File_To_Look_For[0]))
                                            {
                                                MySqlGeneralDataHandler MySql = new MySqlGeneralDataHandler();
                                                MySql.Initialise_General();
                                                MySql.Commit_One_Flight(DataSet);
                                                MySql.CloseConnection();

                                                MySqlCalculatedDataHandler MySql_Calculated = new MySqlCalculatedDataHandler();
                                                MySql_Calculated.Initialise_Calculated();
                                                CalculatedDataSet Calculated_DataSet = new CalculatedDataSet();
                                                MySql_Calculated.Commit_One_Flight(Calculated_DataSet);
                                                MySql_Calculated.CloseConnection();

                                            }
                                            MyStreamReader.Close();
                                            MyStreamReader.Dispose();
                                        }
                                    }
                                }
                                catch
                                {

                                }
                            }

                            // Now try to extract the trajectory from the actual track flown
                            File_To_Look_For = Directory.GetFiles(File_Path + "\\TRACK", "TRACK_FlownTrack.kml", SearchOption.TopDirectoryOnly);

                            if (File_To_Look_For.Length > 0)
                            {
                                XmlTextReader xtr = new XmlTextReader(File_To_Look_For[0]);
                                xtr.WhitespaceHandling = WhitespaceHandling.None;
                                xtr.Read();
                                char[] delimiterChars = { '\n' };

                                string Line;
                                while (xtr.Read()) //load loop
                                {
                                    // Parse the file
                                    if (xtr.Name == "coordinates")
                                    {
                                        Line = xtr.ReadString();
                                        string New_Line = Line.Replace("\t", string.Empty);
                                        string[] Words_One_Point = New_Line.Split(delimiterChars);

                                        char[] One_Line_delimiterChars = { ',' };
                                        String trajectory = "";
                                        bool Is_First_Point = false;
                                        DateTime FirstPointTime = new DateTime();
                                        foreach (string One_Line in Words_One_Point)
                                        {
                                            if (One_Line.Length > 1)
                                            {
                                                string[] One_Point_Data = One_Line.Split(One_Line_delimiterChars);
                                                string LAT, LON, FL, TIME;
                                                LAT = One_Point_Data[0];
                                                LON = One_Point_Data[1];
                                                FL = One_Point_Data[2];
                                                TIME = One_Point_Data[3];
                                                DateTime ThisTime = GetDate_Time_From_YYYYMMDDHHMMSS(TIME);

                                                if (Is_First_Point == false)
                                                {
                                                    Is_First_Point = true;
                                                    FirstPointTime = GetDate_Time_From_YYYYMMDDHHMMSS(TIME);
                                                    TIME = "0";
                                                }
                                                else
                                                {
                                                    TimeSpan CalculateTime = ThisTime - FirstPointTime;
                                                    TIME = Math.Round(CalculateTime.TotalSeconds).ToString();
                                                }

                                                trajectory = trajectory + LON + "," + LAT + "," + FL + "," + TIME + "," + "N/A,;";
                                            }
                                        }

                                        // lat1,lon1,alt1,time1,name1,flags1;lat2,lon2,alt2,time2,name2,flags2;...
                                        //trajectory = "52.3081,4.7642,0,0,EHAM,;52.2442,5.2569,13400,248,IVLUT,;52.1097,5.5653,14000,388,LUNIX,;52.0617,5.6756,16300,434,RENDI,;51.9756,5.8358,19600,509,EDUPO,;51.8558,6.0589,23200,603,NAPRO,;51.7681,6.22,25300,669,DEPAD,;51.6389,6.455,27900,767,AMOSU,;51.4047,6.8758,32100,930,MISGO,;50.7836,7.5942,38900,1291,COL,;50.5214,7.8231,40400,1434,MONAX,;49.7489,8.48,41000,1866,RIDSU,TOC;49.4653,8.6792,41000,2021,ABUKA,;48.9931,8.5842,41000,2252,KRH,;48.17,8.3214,41000,2668,NATOR,;47.8583,8.3967,41000,2823,TITIX,;47.6894,8.4369,41000,2908,TRA,;47.2603,8.5,41000,3120,RIPUS,;47.0394,8.5322,41000,3231,GERSA,TOD;46.6067,8.5942,30500,3435,SOSON,;46.4361,8.6183,26900,3523,DEGAD,;46.1044,8.665,25000,3702,ODINA,;45.5592,9.5072,17000,4142,TZO,;45.2264,9.5411,9700,4349,COD,;45.4494,9.2783,353,4821,LIML,;";
                                        Calculate_Penetration_Points CPP = new Calculate_Penetration_Points();
                                        List<Sectors.Intersection> ip = CPP.Calculate(trajectory);

                                        List<Generate_KML.Waypoint> WPT_List = new List<Generate_KML.Waypoint>();
                                        for (int i = 0; i < ip.Count; i++)
                                        {
                                            Generate_KML.Waypoint WPT = new Generate_KML.Waypoint();
                                            WPT.Flight_Level = ip[i].point.getAltitude().ToString();
                                            WPT.Position.SetPosition(new GeoCordSystemDegMinSecUtilities.LatLongDecimal(ip[i].point.getLatitude(), ip[i].point.getLongitude()));
                                            WPT.ETO = ip[i].point.getTime().ToString();
                                            WPT_List.Add(WPT);
                                        }
                                    
                                        Generate_KML.Generate_Output(WPT_List);
                                       
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }

        public static DateTime GetDate_Time_From_YYYYMMDDHHMMSS(string DATETIME)
        {
            int Year = int.Parse(DATETIME.Substring(0, 4));
            int Month = int.Parse(DATETIME.Substring(4, 2));
            int Day = int.Parse(DATETIME.Substring(6, 2));
            int Hour = int.Parse(DATETIME.Substring(8, 2));
            int Minute = int.Parse(DATETIME.Substring(10, 2));
            int Sec = int.Parse(DATETIME.Substring(12, 2));
            return new DateTime(Year, Month, Day, Hour, Minute, Sec);
        }

        // Extract all data paths
        public static string[] Extract_Paths_To_Each_Flight_To_Be_Analysed(string File_Location)
        {
            string[] Paths_Out = null;
            List<string> Out_List = new List<string>();
            if (System.IO.File.Exists(File_Location))
            {
                MyStreamReader = System.IO.File.OpenText(File_Location);
                int Index = 0;
                while (MyStreamReader.Peek() >= 0)
                {
                    Out_List.Add(MyStreamReader.ReadLine());
                    Index++;
                }

                MyStreamReader.Close();
                MyStreamReader.Dispose();

                // Delete the file as it is not needed anymore
                try
                {
                    if (Properties.Settings.Default.DeleteTriggerFile)
                        System.IO.File.Delete(File_Location);
                }
                catch 
                {
                    MyStreamReader.Close();
                    MyStreamReader.Dispose();
                    if (Properties.Settings.Default.DeleteTriggerFile)
                        System.IO.File.Delete(File_Location);
                }

            }
            if (Out_List.Count > 0)
                Paths_Out = Out_List.ToArray();

            return Paths_Out;
        }
    }
}
