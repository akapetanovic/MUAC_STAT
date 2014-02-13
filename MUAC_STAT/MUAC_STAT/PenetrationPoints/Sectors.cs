using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace PenetrationPoints
{
    class Sectors
    {
        // List of sectors
        private List<Sector> sectors;
        // Outside border of all sectors
        public Sector border;

        public Sectors(int b, int u, String coords)
        {
            sectors = new List<Sector>();
            String [] coord = coords.Split(';');
            List<Point4D> vertices = new List<Point4D>();

            for(int i=0; coord[i] != ""; i++)
		    {
			    String [] data = coord[i].Replace("\\s", "").Split(','); 
                // lokalizacija: decimalni zarez umjesto tačke
                data[0] = data[0].Replace(".", ",");
                data[1] = data[1].Replace(".", ",");
                double lon = Double.Parse(data[0]);
			    double lat = Double.Parse(data[1]);
                vertices.Add(new Point4D(lat, lon, 0, 0));
            }
            Sector s = new Sector("Sector", vertices, b, u);
            this.sectors.Add(s);
            border = s;
        }

        public class Intersection
        {
            public Sector sector;
            public Point4D point;

            public Intersection(Sector s, Point4D p)
            {
                this.sector = s;
                this.point = p;
            }
        }

        public List<Intersection> intersectionWithTrajectory(Trajectory trajectory, int step, int startTime)
	    {
		    List<Intersection> result = new List<Intersection>();
		
		    // precise trajectory
		    List<Point4D> detailedTrajectory = new List<Point4D>(); 

		    // Find start point
		    int start;
		    for(start = 0; trajectory.getTrajectory()[start].getTime() < startTime; start++)
			    ;
		
		    // create detailed trajectory with given precision
		    for(int i=start; i<trajectory.getTrajectory().Count-1; i++)
		    {
			    Point4D startPoint = trajectory.getPoint(i);
			    Point4D endPoint = trajectory.getPoint(i+1);
			
			    int timeDifference = (endPoint.getTime() - startPoint.getTime());
			
			    double lonStep = (endPoint.getLongitude()-startPoint.getLongitude()) * step / timeDifference;
			    double latStep = (endPoint.getLatitude()-startPoint.getLatitude()) * step / timeDifference;
			    double altStep = (double)(endPoint.getAltitude()-startPoint.getAltitude()) * step / timeDifference;
			
			    for(int time = startPoint.getTime(), j=0; time < endPoint.getTime(); time+=step, j++)
			    {
				    double longitude = startPoint.getLongitude() + j*lonStep;
				    double latitude = startPoint.getLatitude() + j*latStep;
				    int altitude = (int) (startPoint.getAltitude() + j*altStep);
				
				    Point4D point = new Point4D(
						    latitude,
                            longitude,
						    altitude,
						    time);
				    detailedTrajectory.Add(point);
			    }
		    }
		
		    // Find enter point into sectors
		    for(start=0; start<detailedTrajectory.Count; start++)
			    if(border.pointInside(detailedTrajectory[start]))
				    break;
            
		    // No intersections
		    if(start == detailedTrajectory.Count)
			    return result;
		
		    for( ; start<detailedTrajectory.Count; start++)
			    if(sectorIn(detailedTrajectory[start]) != null)
				    break;
		    // No intersections
		    if(start == detailedTrajectory.Count)
			    return result;
		
		    Sector currentSector = sectorIn(detailedTrajectory[start]);
		    Point4D intersectionPoint = detailedTrajectory[start];
		    intersectionPoint.setType(Point4D.Type.IN);
		    result.Add(new Intersection(currentSector, intersectionPoint));
		
		    
		    for(int i=start; i<detailedTrajectory.Count; i++)
		    {
			    if(currentSector.pointInside(detailedTrajectory[i]))
				    continue;
			    Point4D intersectionPointOUT = detailedTrajectory[i-1];
			    intersectionPointOUT.setType(Point4D.Type.OUT);
			    result.Add(new Intersection(currentSector, intersectionPointOUT));
			    currentSector = sectorIn(detailedTrajectory[i]);
			    while(currentSector == null)
			    {
				    i++;
				    if(i == detailedTrajectory.Count)
					    goto end;
				    currentSector = sectorIn(detailedTrajectory[i]);
			    }
			    Point4D intersectionPointIN = detailedTrajectory[i];
			    intersectionPointIN.setType(Point4D.Type.IN);
			    result.Add(new Intersection(currentSector, intersectionPointIN));
		    }
		    end:
		    return result;
	    }
	
	    public Sector sectorIn(Point4D p)
	    {
		    for(int i=0; i<this.sectors.Count; i++)
			    if(this.sectors[i].pointInside(p))
				    return this.sectors[i];
		    return null;
	    }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < this.sectors.Count; i++)
                str += this.sectors[i] + "\n";
            return str;
        }
            
    }
}
