using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MUAC_STAT
{
    public class Sector
    {
        public int Lower_Level = 220;
        public int Upper_Level = 660;
        public List<GeoCordSystemDegMinSecUtilities.LatLongClass> Sector_List = new List<GeoCordSystemDegMinSecUtilities.LatLongClass>();
       
        public void Initialise()
        {
            StreamReader MyStreamReader;
            string OneLine;
            char[] delimiterChars = { ',' };

            try
            {
                using (MyStreamReader = System.IO.File.OpenText(Properties.Settings.Default.Border))
                {
                    if (MyStreamReader != null)
                    {
                         // Parse the file and extract all data needed by EFD
                        while (MyStreamReader.Peek() >= 0)
                        {
                            OneLine = MyStreamReader.ReadLine();
                            string[] Words = OneLine.Split(delimiterChars);
                            GeoCordSystemDegMinSecUtilities.LatLongClass SectorPoint = new GeoCordSystemDegMinSecUtilities.LatLongClass(double.Parse(Words[0]), double.Parse(Words[1]));
                            Sector_List.Add(SectorPoint);
                        }

                    }
                }
            }
            catch
            {
                
            }
        }

    }
}
