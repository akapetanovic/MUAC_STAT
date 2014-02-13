using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUAC_STAT
{
    public class Entry_Exit
    {
        public bool Entry_Found = false;
        public bool Exit_Found = false;
        GeoCordSystemDegMinSecUtilities.LatLongClass Entry_Point = new GeoCordSystemDegMinSecUtilities.LatLongClass();
        GeoCordSystemDegMinSecUtilities.LatLongClass Exit_Point = new GeoCordSystemDegMinSecUtilities.LatLongClass();

        public void DeterminePoints(List<GeoCordSystemDegMinSecUtilities.LatLongClass> Trajectory_List, List<GeoCordSystemDegMinSecUtilities.LatLongClass> Sector_Point_List)
        {
            RayCastAlghoritym RCA = new RayCastAlghoritym();

            for (int Index = 0; Index < Trajectory_List.Count; Index++)
            {
                if (RCA.Is_Point_Inside_Polygon(Trajectory_List[Index].GetLatLongDecimal().LatitudeDecimal,
                    Trajectory_List[Index].GetLatLongDecimal().LongitudeDecimal, Sector_Point_List) == true)
                {
                    if (Entry_Found == false)
                    {
                        Entry_Point = Trajectory_List[Index];
                        Entry_Found = true;
                    }
                }
                else
                {
                    if (Entry_Found == true && Exit_Found == false)
                    {
                        Exit_Point = Trajectory_List[Index - 1];
                        Exit_Found = true;
                    }
                }
            }
        }
    }
}
