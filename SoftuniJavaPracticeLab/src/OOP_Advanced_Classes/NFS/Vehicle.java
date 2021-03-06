package OOP_Advanced_Classes.NFS;

import SoftuniRelatedExercises.OOP_Basics_Classes.Department;

import java.sql.SQLInvalidAuthorizationSpecException;

public abstract class Vehicle {
    public final  double DEFAULT_FUEL_CONSUMPTION;

    private double fuelConsumption;
    private double fuel;
    private int horsePower;

    public Vehicle(double fuel,int horsePower){
        this.setFuelConsumption(1.25);
        this.setFuel(fuel);
        this.setHorsePower(horsePower);
        DEFAULT_FUEL_CONSUMPTION = this.getFuelConsumption();
    }



    public double getFuel(){return this.fuel;}

    private void setFuel(double fuel){
        if(fuel<0){
            throw new IllegalArgumentException("Illegal fuel state.");
        }else{
            this.fuel = fuel;
        }
    }

    public int getHorsePower(){return this.horsePower;}

    private void setHorsePower(int horsePower){
        if(horsePower<1){
            throw new IllegalArgumentException("Illegal fuel state.");
        }else{
            this.horsePower = horsePower;
        }
    }

    public double getFuelConsumption(){return this.fuelConsumption;}

    protected void setFuelConsumption(double value){
        if(value<=0){
            throw new IllegalArgumentException("Illegal fuel consumption state.");
        }else{
            this.fuelConsumption = value;
        }
    }

    public void drive(double kilometers){
    double fuelConsumed = kilometers*this.getFuelConsumption();
    if(fuelConsumed<this.getFuel()){
        this.setFuel(this.getFuel()-fuelConsumed);
    }else if(fuelConsumed>=this.getFuel()){
        this.setFuel(0);
    }

    }


}
