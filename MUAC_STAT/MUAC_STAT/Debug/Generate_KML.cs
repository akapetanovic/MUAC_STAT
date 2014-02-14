using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MUAC_STAT
{
    class Generate_KML
    {
        public class Waypoint
        {
            public GeoCordSystemDegMinSecUtilities.LatLongClass Position = new GeoCordSystemDegMinSecUtilities.LatLongClass();
            public string Flight_Level = "N/A";
            public string ETO = "N/A";
        }

        public static void Generate_Output(List<Waypoint> WPT_List)
        {
            string TIME_AS_YYYYMMDDHHMMSS = GetDate_Time_AS_YYYYMMDDHHMMSS(DateTime.UtcNow);
            string Time_Stamp = KML_Common.Get_KML_Time_Stamp();

            // Here build the trajectory string
            // "12.17152,51.41049,646,20130305003800" + Environment.NewLine +
            // "12.09607,51.41915,1201,20130305003900" + Environment.NewLine +
            string Trajectory_String = "";
            foreach (Waypoint WPT in WPT_List)
            {
                Trajectory_String = Trajectory_String + string.Format("{0:0.0000}", WPT.Position.GetLatLongDecimal().LongitudeDecimal) + "," +
                    string.Format("{0:0.0000}", WPT.Position.GetLatLongDecimal().LatitudeDecimal) + "," +
                    WPT.Flight_Level + "," + WPT.ETO + Environment.NewLine;
            }

            string KML_File_Content =
           "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine +
                   "<kml xmlns=\"http://www.opengis.net/kml/2.2\">" + Environment.NewLine +
                   "<Document>" + Environment.NewLine +
           "<Placemark>" + Environment.NewLine +
              "<name>" + "ACID" + " Trajectory" + "</name>" + Environment.NewLine +
           "<TimeStamp>" + Environment.NewLine +
                       "<when>" + Time_Stamp + "</when>" + Environment.NewLine +
                   "</TimeStamp>" + Environment.NewLine +
           "<ExtendedData>" + Environment.NewLine +
               "<Data name=\"dataSourceName\">" + Environment.NewLine +
                    "<value>EFD</value>" + Environment.NewLine +
                 "</Data>" + Environment.NewLine +
               "<Data name=\"markerType\">" + Environment.NewLine +
                  " <value>polyline</value>" + Environment.NewLine +
               "</Data>" + Environment.NewLine +
               "<Data name=\"lineColor\">" + Environment.NewLine +
                   "<value>ffff00</value>" + Environment.NewLine +
              "</Data>" + Environment.NewLine +
               "<Data name=\"popupLine1\">" + Environment.NewLine +
                   "<value>" + "ACID" + ',' + "ACID" + ',' + "ACID" + "</value>" + Environment.NewLine +
                   "</Data>" + Environment.NewLine +
                 "<Data name=\"popupLine2\">" + Environment.NewLine +
                      "<value>" + "ACID" + "</value>" + Environment.NewLine +
                 "</Data>" + Environment.NewLine +
                 "<Data name=\"popupLine3\">" + Environment.NewLine +
                       "<value>" + "ACID" + "</value>" + Environment.NewLine +
                 "</Data>" + Environment.NewLine +
                 "<Data name=\"fileLocation\">" + Environment.NewLine +
                       "<value>ACID</value>" + Environment.NewLine +
                 "</Data>" + Environment.NewLine +
           "</ExtendedData>" + Environment.NewLine +
                "<LineString>" + Environment.NewLine +
                       "<coordinates>" + Environment.NewLine +
                       Trajectory_String +
                   "</coordinates>" + Environment.NewLine +
                 "</LineString>" + Environment.NewLine +
             "</Placemark>" + Environment.NewLine +
           "</Document>" + Environment.NewLine +
           "</kml>";

            // Save data in the tmp directory first
            string Tmp = @"C:\var\STATISTICS\Temp_KML.kml";

            // create a writer and open the file
            TextWriter tw = new StreamWriter(Tmp);

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

        public static string GetDate_Time_AS_YYYYMMDDHHMMSS(DateTime Time_In)
        {
            return Time_In.Year.ToString("0000") + Time_In.Month.ToString("00") + Time_In.Day.ToString("00") + Time_In.Hour.ToString("00") + Time_In.Minute.ToString("00") + Time_In.Second.ToString("00");
        }
    }
}
