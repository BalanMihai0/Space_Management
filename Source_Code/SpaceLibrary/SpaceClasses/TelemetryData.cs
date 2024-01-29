
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TelemetryData {


    private double temperature;
    private double batteryLevel;
    private double hullIntegrity;
    private double boardComputerHealth;

    //when creating this, all values are default
    public TelemetryData()
    {
        this.temperature = 50;
        this.batteryLevel = 100;
        this.hullIntegrity = 100;
        this.boardComputerHealth = 100;
    }
    //used for creating with already existing data
    public TelemetryData(double temperature, double batteryLevel, double hullIntegrity, double boardComputerHealth) 
    {
        this.temperature = temperature;
        this.batteryLevel = batteryLevel;
        this.hullIntegrity = hullIntegrity;
        this.boardComputerHealth = boardComputerHealth;

    }
    /// <summary>
    /// the batteryLevel, hullIntegrity and boardComputerHealth are treated as 
    /// percentages ( 0 - 100 %)
    /// the setters prevent the entering of an invalid percentage
    /// invalid percentages will be autocorrected
    /// getters are public and are used to see the data
    /// </summary>
    
    #region Properties

    public double BatteryLevel
    {
        private set
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            this.batteryLevel = value;
        }
        get => this.batteryLevel;
    }
    public double Temperature
    {
        private set
        {
            this.temperature = value;
        }
        get => this.temperature;
    }
    public double HullIntegrity
    {
        private set
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            this.hullIntegrity = value;
        }
        get => this.hullIntegrity;
    }
    public double BoardComputerHealth
    {
        private set
        {
            if (value < 0) value = 0;
            if (value > 100) value = 100;
            this.boardComputerHealth = value;
        }
        get => this.boardComputerHealth;
    }
    #endregion

    public void RechargeBattery() {
        this.batteryLevel = 100;
    }

    public string CheckBattery()
    {
        if (this.batteryLevel == 0)
            return "Dead";
        if (this.batteryLevel > 0 && this.batteryLevel <= 10)
            return "Critical";
        if (this.batteryLevel > 10 && this.batteryLevel <= 50)
            return "Working";
        if (this.batteryLevel > 50 && this.batteryLevel <= 80)
            return "Good";
        if (this.batteryLevel > 80 && this.batteryLevel < 100)
            return "Great";
        if (this.batteryLevel == 100)
            return "Full";
        return "N/A";
    }

    public string CheckTemperature() 
    {
        if (this.temperature >= -100 && this.temperature <= 100)
            return "Normal";
        if (this.temperature < -100)
            return "Cold";
        if (this.temperature > 100 && this.temperature <= 500)
            return "Hot";
        if (this.temperature > 500)
            return "Burning";
        return "N/A";
    }

    public bool HasValue()
    {
        return !(this.temperature <= -1 || this.batteryLevel <= 0 || this.batteryLevel == 0 || this.BoardComputerHealth == 0 || this.hullIntegrity == 0);
    }
}