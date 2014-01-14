using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MUAC_STAT
{
    public class Trajectory
    {
        public List<GeoCordSystemDegMinSecUtilities.LatLongClass> Trajectory_Point_List = new List<GeoCordSystemDegMinSecUtilities.LatLongClass>();
       
        public void Initialise()
        {
            //StreamReader MyStreamReader;
            //string OneLine;
            //char[] delimiterChars = { ',' };

            //try
            //{
            //    using (MyStreamReader = System.IO.File.OpenText(Properties.Settings.Default.Trajectory))
            //    {
            //        if (MyStreamReader != null)
            //        {
            //             // Parse the file and extract all data needed by EFD
            //            while (MyStreamReader.Peek() >= 0)
            //            {
            //                OneLine = MyStreamReader.ReadLine();
            //                string[] Words = OneLine.Split(delimiterChars);
            //                GeoCordSystemDegMinSecUtilities.LatLongClass SectorPoint = new GeoCordSystemDegMinSecUtilities.LatLongClass(double.Parse(Words[0]), double.Parse(Words[1]));
            //                Trajectory_Point_List.Add(SectorPoint);
            //            }

            //        }
            //    }

            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //}
        }

    }
}
