using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PenetrationPoints
{
    class Point4D
    {
        private double longitude;
        private double latitude;
        private int altitude;
        private int time;
        private Type type;

        public enum Type
	    {
		    IN, OUT, NONE
	    };

        public Point4D(Point4D p)
        {
            this.altitude = p.altitude;
            this.latitude = p.latitude;
            this.longitude = p.longitude;
            this.time = p.time;
            this.type = p.type;
        }

        public Point4D(double latitude, double longitude, int altitude, int time)
        {
            this.longitude = longitude;
            this.latitude = latitude;
            this.altitude = altitude;
            this.time = time;
            type = Type.NONE;
        }

        public override string ToString()
        {
            String str = this.latitude + ", " + this.longitude + ", " + this.altitude + ", " + this.time + ", " + this.type + "\n";
		    return str;
        }

        public int getAltitude()
        {
            return altitude;
        }

        public double getLatitude()
        {
            return latitude;
        }

        public double getLongitude()
        {
            return longitude;
        }

        public int getTime()
        {
            return time;
        }

        public Type getType()
        {
            return type;
        }

        public void setTime(int time)
        {
            this.time = time;
        }

        public String toKMLString()
	    {
	    	String str = this.longitude + "," + this.latitude + "\n";
	    	return str;
	    }

        public void setType(Type type)
        {
            this.type = type;
        }
    }
}
