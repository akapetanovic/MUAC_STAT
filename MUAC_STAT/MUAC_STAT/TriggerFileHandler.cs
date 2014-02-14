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
                                        foreach (string One_Line in Words_One_Point)
                                        {
                                            if (One_Line.Length > 1)
                                            {
                                                string[] One_Point_Data = One_Line.Split(One_Line_delimiterChars);
                                                //LAT,LON,FL,TIME,SPEED
                                              
                                            }
                                        }

                                        // lat1,lon1,alt1,time1,name1,flags1;lat2,lon2,alt2,time2,name2,flags2;...
                                        String trajectory = "52.3081,4.7642,0,0,EHAM,;52.2442,5.2569,13400,248,IVLUT,;52.1097,5.5653,14000,388,LUNIX,;52.0617,5.6756,16300,434,RENDI,;51.9756,5.8358,19600,509,EDUPO,;51.8558,6.0589,23200,603,NAPRO,;51.7681,6.22,25300,669,DEPAD,;51.6389,6.455,27900,767,AMOSU,;51.4047,6.8758,32100,930,MISGO,;50.7836,7.5942,38900,1291,COL,;50.5214,7.8231,40400,1434,MONAX,;49.7489,8.48,41000,1866,RIDSU,TOC;49.4653,8.6792,41000,2021,ABUKA,;48.9931,8.5842,41000,2252,KRH,;48.17,8.3214,41000,2668,NATOR,;47.8583,8.3967,41000,2823,TITIX,;47.6894,8.4369,41000,2908,TRA,;47.2603,8.5,41000,3120,RIPUS,;47.0394,8.5322,41000,3231,GERSA,TOD;46.6067,8.5942,30500,3435,SOSON,;46.4361,8.6183,26900,3523,DEGAD,;46.1044,8.665,25000,3702,ODINA,;45.5592,9.5072,17000,4142,TZO,;45.2264,9.5411,9700,4349,COD,;45.4494,9.2783,353,4821,LIML,;";
                                        PenetrationPoints.Trajectory t = new PenetrationPoints.Trajectory(trajectory, 0);
                                        Sectors s = new Sectors(245, 900, "8.1738888889,51.2041666667;8.4111111111,51.27;8.4913888889,51.1963888889;8.6141666667,51.0833333333;8.9097222222,51.0855555556;9.2452777778,51.0855555556;9.4333333333,51.0855555556;10.0408333333,51.0833333333;10.0558333333,51.095;10.3875,51.3338888889;10.5925,51.4869444444;10.7,51.5666666667;11.1438888889,51.8063888889;11.2083333333,51.8413888889;11.13,51.9066666667;11.0916666667,52.2083333333;11.0805555556,52.2919444444;11.0702777778,52.3736111111;11.0816666667,52.4669444444;11.0833333333,52.4797222222;11.1072222222,52.7308333333;11.3436111111,52.7686111111;11.2983333333,53.1088888889;11.4302777778,53.3625;11.4438888889,53.3958333333;11.8927777778,54.2502777778;11.6383333333,54.2958333333;11.0347222222,54.5466666667;10.9833333333,54.5669444444;10.8833333333,54.5952777778;10.6666666667,54.6558333333;10.5,54.6586111111;10.0494444444,54.6547222222;8.75,54.6336111111;8.6666666667,54.7002777778;8.6666666667,54.9169444444;8.4486111111,55.0716666667;8.3919444444,55.0694444444;8.3333333333,55.0669444444;8,55.0002777778;6.5,55.0002777778;5,55.0002777778;4.5358333333,54.5002777778;4.5333333333,54.5002777778;4.1777777778,54.1113888889;4.18,54.1058333333;4.0852777778,54.0002777778;3.9427777778,53.8397222222;3.7061111111,53.57;3.6497222222,53.5002777778;3.5611111111,53.4027777778;3.4294444444,53.2494444444;3.3661111111,53.175;3.3033333333,53.1011111111;3.2547222222,53.0436111111;3.1480555556,52.9172222222;3.0683333333,52.8222222222;2.9941666667,52.7330555556;2.8988888889,52.6180555556;2.8408333333,52.5472222222;2.8291666667,52.5333333333;2.7788888889,52.4722222222;2.7102777778,52.3888888889;2.6436111111,52.3075;2.4877777778,52.1147222222;2.3563888889,51.9505555556;3.1719444444,51.9658333333;3.1719444444,51.9244444444;3.1719444444,51.4805555556;2.5,51.6369444444;2.5,51.4555555556;2,51.5;2,51.4;2,51.3833333333;2,51.3591666667;2,51.1166666667;1.9883333333,51.1141666667;1.6927777778,51.0497222222;2.8333333333,50.6919444444;3.2705555556,50.5433333333;3.2788888889,50.5275;3.3758333333,50.5033333333;3.4941666667,50.5275;3.5238888889,50.5080555556;3.5869444444,50.5033333333;3.3444444444,50.1833333333;3.63,50.1094444444;3.8202777778,50.0597222222;4.1488888889,49.9730555556;4.2319444444,49.9611111111;4.3544444444,49.8966666667;4.7555555556,49.6833333333;4.9755555556,49.5647222222;5.1013888889,49.4963888889;5.125,49.4833333333;5.8111111111,49.4311111111;5.8305555556,49.3477777778;5.9513888889,48.8325;6.2302777778,48.8194444444;6.2763888889,48.8175;6.75,48.975;6.7102777778,49.2194444444;7,49.7833333333;6.6,49.9666666667;6.6233333333,50.0513888889;7.1166666667,50.1833333333;7.3,50.6333333333;7.8166666667,50.7208333333;7.6833333333,50.8333333333;7.6822222222,50.9325;7.95,51.1;7.9713888889,51.11;8.0522222222,51.1475;8.1738888889,51.2041666667;");

                                        List<Sectors.Intersection> ip = s.intersectionWithTrajectory(t, 1, 0);

                                        for (int i = 0; i < ip.Count; i++)
                                        {

                                        }

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
