using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MUAC_STAT
{
    class RayCastAlghoritym
    {

        public bool Is_Point_Inside_Polygon(double lat, double lon, List<GeoCordSystemDegMinSecUtilities.LatLongClass> SectorPoints)
        {
            bool isSelected = false;
            
            //Ray-cast algorithm is here onward
            int k, j = SectorPoints.Count - 1;

            bool oddNodes = false; //to check whether number of intersections is odd
            for (k = 0; k < SectorPoints.Count; k++)
            {
                //fetch adjucent points of the polygon
                GeoCordSystemDegMinSecUtilities.LatLongClass polyK = SectorPoints[k];
                GeoCordSystemDegMinSecUtilities.LatLongClass polyJ = SectorPoints[j];

                //check the intersections
                //if (((polyK.Y > currentPoint.Y) != (polyJ.Y > currentPoint.Y)) &&
                // (currentPoint.X < (polyJ.X - polyK.X) * (currentPoint.Y - polyK.Y) / (polyJ.Y - polyK.Y) + polyK.X))
                //    oddNodes = !oddNodes; //switch between odd and even
                
                //check the intersections
                if (((polyK.GetLatLongDecimal().LongitudeDecimal > lon) != (polyJ.GetLatLongDecimal().LongitudeDecimal > lon)) &&
                 (lat < (polyJ.GetLatLongDecimal().LatitudeDecimal - polyK.GetLatLongDecimal().LatitudeDecimal) * (lon - polyK.GetLatLongDecimal().LongitudeDecimal) / (polyJ.GetLatLongDecimal().LongitudeDecimal - polyK.GetLatLongDecimal().LongitudeDecimal) + polyK.GetLatLongDecimal().LatitudeDecimal))
                    oddNodes = !oddNodes; //switch between odd and even

                j = k;
            }

            //if odd number of intersections
            if (oddNodes)
            {
                //mouse point is inside the polygon
                isSelected = true;
            }
            else //if even number of intersections
            {
                //mouse point is outside the polygon so deselect the polygon
                isSelected = false;
            }

            return isSelected;

        }

    }
}
