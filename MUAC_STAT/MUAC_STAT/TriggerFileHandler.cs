using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Timers;
using System.Xml;


namespace MUAC_STAT
{
    public static class TriggerFileHandler
    {
        private static bool ProcessingEnabled = true;
        //List<string> MessageList = new List<string>();

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
                                            OneFlightDataSet DataSet = new OneFlightDataSet();
                                            if (DataSet.Populate_General_Data(File_To_Look_For[0]))
                                            {
                                                MySqlHandler MySql = new MySqlHandler();
                                                MySql.Initialise(Properties.Settings.Default.MySqlServer, Properties.Settings.Default.MySqlLogin, Properties.Settings.Default.MySqlDatabase, Properties.Settings.Default.MySqlTable);
                                                MySql.Commit_One_Flight(DataSet);
                                                MySql.CloseConnection();
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

                                        List<GeoCordSystemDegMinSecUtilities.LatLongClass> Trajectory_Point_List = new List<GeoCordSystemDegMinSecUtilities.LatLongClass>();

                                        char[] One_Line_delimiterChars = { ',' };
                                        foreach (string One_Line in Words_One_Point)
                                        {
                                            if (One_Line.Length > 1)
                                            {
                                                string[] One_Point_Data = One_Line.Split(One_Line_delimiterChars);
                                                //LAT,LON,FL,TIME,SPEED
                                                Trajectory_Point_List.Add(new GeoCordSystemDegMinSecUtilities.LatLongClass(double.Parse(One_Point_Data[0]), double.Parse(One_Point_Data[1]))); 
                                            }
                                        }

                                        Sector SectorBorder = new Sector();
                                        SectorBorder.Initialise();

                                        Entry_Exit EX = new Entry_Exit();
                                        EX.DeterminePoints(Trajectory_Point_List, SectorBorder.Sector_List);
                                        
                                        /////////////////////////////////////////////////////////////////////
                                        // DEBUG CODE, outputs data to KML file
                                        List<GeoCordSystemDegMinSecUtilities.LatLongClass> Entry_Exit_Pair_List = new List<GeoCordSystemDegMinSecUtilities.LatLongClass>();
                                        Entry_Exit_Pair_List.Add(EX.Entry_Point);
                                        Entry_Exit_Pair_List.Add(EX.Exit_Point);

                                        Write_Trajectory.Generate_Output(Trajectory_Point_List, "Trajectory_" + File_Path.Substring(File_Path.Length - 10));
                                        Write_Trajectory.Generate_Output(Entry_Exit_Pair_List, "Entry_Exit_" + File_Path.Substring(File_Path.Length - 10));
                                        //////////////////////////////////////////////////////////////////////
                                        
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
                catch (Exception e)
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
