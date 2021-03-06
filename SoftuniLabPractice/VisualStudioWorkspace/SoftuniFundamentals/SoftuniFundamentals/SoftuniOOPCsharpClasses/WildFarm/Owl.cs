﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SoftuniFundamentals.SoftuniOOPCsharpClasses.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name,double weight,double wingSize,int foodEaten) : base(name,weight,wingSize,foodEaten) { }
        

        public override void EatFood(Food food)
        {

            if (food is Meat)
            {
                this.FoodEaten += food.Quantity;
                this.Weight += (food.Quantity * 0.25);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} cannot eat {food.GetType().Name}");
            }
        }


        public override string Talk()
        {
            return "Hoot Hoot!";
        }
    }
}
