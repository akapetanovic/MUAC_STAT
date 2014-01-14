using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MUAC_STAT
{
    class Write_Trajectory
    {

        public static void Generate_Output(List<GeoCordSystemDegMinSecUtilities.LatLongClass> Trajectory_List, string File_Name)
        {

            string Trajectory_String = "";
            foreach (GeoCordSystemDegMinSecUtilities.LatLongClass WPT in Trajectory_List)
            {
                Trajectory_String = Trajectory_String + string.Format("{0:0.0000}", WPT.GetLatLongDecimal().LatitudeDecimal) + "," +
                    string.Format("{0:0.0000}", WPT.GetLatLongDecimal().LongitudeDecimal) + Environment.NewLine;
            }

            string KML_File_Content =
           "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine +
                   "<kml xmlns=\"http://www.opengis.net/kml/2.2\">" + Environment.NewLine +
                   "<Document>" + Environment.NewLine +
           "<Placemark>" + Environment.NewLine +
                "<LineString>" + Environment.NewLine +
                       "<coordinates>" + Environment.NewLine +
                       Trajectory_String +
                   "</coordinates>" + Environment.NewLine +
                 "</LineString>" + Environment.NewLine +
             "</Placemark>" + Environment.NewLine +
           "</Document>" + Environment.NewLine +
           "</kml>";

            // Get the final data path
            
            string File_Path = Path.Combine(Properties.Settings.Default.DEBUG, ("Trajectory_" + File_Name + ".kml"));

            // create a writer and open the file
            TextWriter tw = new StreamWriter(File_Path);

            try
            {
                // write a line of text to the file
                tw.Write(KML_File_Content);
            
            }
            catch
            {
 
            }

            // close the stream
            tw.Close();
        }
    }
}
