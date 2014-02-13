using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PenetrationPoints
{
    class Trajectory
    {
        //Start time
        private int startTime;
        //Points of trajectory
        private List<Point4D> trajectory;
	
        public Trajectory(String traj, int startT)
	    {
		    this.trajectory = new List<Point4D>();
	  
		    try{
		
			    List<Point4D> trajectory = new List<Point4D>(); 
			    int startTime = startT;
		   
			    String [] trajEvent = traj.Split(';');
		        for(int i=0; trajEvent[i] != ""; i++)
		        {
			        String [] data = trajEvent[i].Replace("\\s", "").Split(',');
			        // lokalizacija: decimalni zarez umjesto tačke
                    data[0] = data[0].Replace(".", ",");
                    data[1] = data[1].Replace(".", ",");
			        double lat = Double.Parse(data[0]);
                    double lon = Double.Parse(data[1]);
			        int alt = Int32.Parse(data[2])/100;
			        int time = Int32.Parse(data[3]);
			        Point4D point = new Point4D(lat, lon, alt, time);
			        trajectory.Add(point);
		        }
		 
		        for(int i=0; i<trajectory.Count; i++)
		    	    this.trajectory.Add(trajectory[i]);
		   
		        this.startTime = startTime;
		  	    } 
		    catch(Exception ex)
		    {
			    Console.WriteLine(ex.Message);
		    }	
        }
        
        public int getStartTime() {
		    return startTime;
	    }
	
	    public void setStartTime(int startTime) {
		    this.startTime = startTime;
	    }
	
	    public List<Point4D> getTrajectory() {
		    return trajectory;
	    }
	
	    public Point4D getPoint(int i)
	    {
		    return this.trajectory[i];
	    }
	
	    public Point4D getLastPoint()
	    {
		    return this.trajectory[this.trajectory.Count-1];
	    }

        public override string ToString()
        {
            String str = "";
            for (int i = 0; i < trajectory.Count; i++)
                str += trajectory[i].ToString();
            return str;
        }
    }
}
 