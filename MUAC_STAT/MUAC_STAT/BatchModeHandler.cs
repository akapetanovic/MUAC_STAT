using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Timers;

namespace MUAC_STAT
{
    public static class BatchModeHandler
    {
        private static bool ProcessingEnabled = true;
        //List<string> MessageList = new List<string>();
        
        private static StreamReader MyStreamReader;
        // Timer to periodically create EFD_Status.xml file
        // as status indication of the module.

        // Define minute of the previous cycle
        private static int Previous_Cycle_Minute = DateTime.Now.Minute - 1;

        private static System.Timers.Timer System_Status_Timer;

        public static void EnableProcessing (bool enable)
        {
            ProcessingEnabled = enable;
        }
        public static void Initialise()
        {
            // Now start heart beat timer.
            System_Status_Timer = new System.Timers.Timer(500); // Set up the timer for 5 sec
            System_Status_Timer.Elapsed += new ElapsedEventHandler(System_Status_Periodic_Update);
            System_Status_Timer.Enabled = true;
        }

        // Periodically call System Status Handler
        private static void System_Status_Periodic_Update(object sender, ElapsedEventArgs e)
        {
            if (ProcessingEnabled)
            {

                DateTime Now = DateTime.Now;
                // Once minute passes then lets process
                // files from the previous minute
                if (Previous_Cycle_Minute != Now.Minute)
                {
                    // First sync times
                    Previous_Cycle_Minute = Now.Minute;
                    System_Status_Timer.Enabled = false;
                    Handle_New_File();
                    System_Status_Timer.Enabled = true;
                }
            }
        }

        public static void Handle_New_File()
        {
            try
            {

                string[] filePaths = Directory.GetFiles(Properties.Settings.Default.TriggerLocation, "*.*", SearchOption.AllDirectories);

                foreach (string Path in filePaths)
                {
                    try
                    {
                        using (MyStreamReader = System.IO.File.OpenText(Path))
                        {
                            if (MyStreamReader != null)
                            {
                                MyStreamReader.Close();
                                MyStreamReader.Dispose();

                            }
                        }
                    }
                    catch
                    {
                        
                    }
                }
            }
            catch 
            {
                
            }
        }
    }
}
