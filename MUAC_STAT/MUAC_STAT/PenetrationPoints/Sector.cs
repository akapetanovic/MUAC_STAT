using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PenetrationPoints
{
    class Sector
    {
        String name;
        // List of vertices of contour base polygon
        private List<Point4D> vertices;
        // Bottom altitude
        private int bottomAltitude;
        // Top altitude
        private int topAltitude;
        // Rectangular borders of sector
        private Point4D[] borders = null;
        
        public Sector(String name, List<Point4D> vertices, int bAlt, int tAlt)
        {
            this.name = name;
            this.vertices = new List<Point4D>(vertices);
            this.bottomAltitude = bAlt;
            this.topAltitude = tAlt;
            this.borders = this.getBorders();
        }

        public bool pointInside(Point4D p) 
	    {
		    if(	p.getLatitude() < borders[0].getLatitude() ||
			    p.getLongitude() < borders[0].getLongitude() ||
			    p.getLatitude() > borders[1].getLatitude() ||
			    p.getLongitude() > borders[1].getLongitude())
			    return false;
		    if( p.getAltitude() < this.bottomAltitude || 
			    p.getAltitude() > this.topAltitude )
			    return false;
            int i, j = this.vertices.Count-1;
		    double x = p.getLongitude();
		    double y = p.getLatitude();
		
		    bool oddNodes=false;

		    for (i=0; i<this.vertices.Count; i++) 
		    {
			    double xi = this.vertices[i].getLongitude();
			    double yi = this.vertices[i].getLatitude();
			    double xj = this.vertices[j].getLongitude();
			    double yj = this.vertices[j].getLatitude();
			
			    if ((yi < y && yj >= y || yj < y && yi >= y) &&  (xi <= x || xj <=x)) 
				    if (xi+(y-yi)/(yj-yi)*(xj-xi) < x) 
					    oddNodes=!oddNodes; 
			    j=i; 
		    }
			
		    return oddNodes; 
	    }
	
	    public String getName() {
		    return name;
	    }

        public override string ToString()
        {
            return this.name + "," + this.bottomAltitude + ","  + this.topAltitude;
        }

	    public Point4D[] getBorders()
	    {
		    double 	minLon = Double.MaxValue,
				    minLat = Double.MaxValue,
				    maxLon = Double.MinValue,
				    maxLat = Double.MinValue;
		
		    for(int i=0; i<this.vertices.Count; i++)
		    {
			    if(this.vertices[i].getLongitude() > maxLon)
				    maxLon = this.vertices[i].getLongitude();
			    if(this.vertices[i].getLongitude() < minLon)
				    minLon = this.vertices[i].getLongitude();
			    if(this.vertices[i].getLatitude() > maxLat)
				    maxLat = this.vertices[i].getLatitude();
			    if(this.vertices[i].getLatitude() < minLat)
				    minLat = this.vertices[i].getLatitude();
		    }			
		    Point4D[] result = new Point4D[2];
            result[0] = new Point4D(minLat, minLon, 0, 0);
            result[1] = new Point4D(maxLat, maxLon, 0, 0);
		    return result;
	    }
	
    }
}
