﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SoftuniFundamentals.Csharp_Advanced_Classes
{
   public class Car
    {
        //adding fields
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car() : this("VW", "Golf", 2025, 200, 10)
        {

        }

        public Car(string make,string model,int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption)
            :this(make,model,year)
        {
            
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;

        }

        //adding properties with validation
        public string Make { get; set; }
        public string Model { get; set; }

        public int Year
        {
             get { return this.year; }

            private set
            { 
                if(value<=0 || value<=1950)
                {
                    throw new ArgumentException("year cannot be les or equal to 0 or 1960");
                }
                else
                {
                    this.year = value;
                }
            }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Quantity has to above 0");
                }
                else
                {
                    this.fuelConsumption = value;
                }
            }
        }

        public double FuelConsumption
        {
            get { return this.fuelConsumption;  }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Consumption has to be above 0");
                }
                else
                {
                    this.fuelConsumption = value;
                }
            }
        }

    }
}
