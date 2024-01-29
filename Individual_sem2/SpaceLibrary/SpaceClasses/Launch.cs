
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

public class Launch {

    private DateTime launchDate;
    private Vector3 launchLocation;
    private DateTime? landingDate;
    public Launch() {
    //used in unit testing with fake data
        this.launchDate = DateTime.Now;
        this.launchLocation = new Vector3(0, 0, 0);
    }

    public Launch(Vector3 launchPosition)
    //used when creating new launch - happens now
    {
        this.launchDate = DateTime.Now;
        this.launchLocation = launchPosition;
    }


    public Launch(DateTime launchDate, Vector3 launchLocation, DateTime landingDate) 
    //extracting from db
    {
        this.launchDate = launchDate;   
        this.launchLocation = launchLocation;
    }

    public DateTime LaunchDate { get { return this.launchDate; } private set { this.launchDate = value; } } 
    public Vector3 LaunchLocation { get {  return this.launchLocation; } }
    public DateTime? LandingDate { get { return this.landingDate; } private set { this.landingDate = value; } }

    public void Land() 
    {
        this.landingDate = DateTime.Now;
    }
}