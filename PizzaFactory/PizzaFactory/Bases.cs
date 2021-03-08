using System;
using System.Collections.Generic;
using System.Text;


namespace PizzaFactory
{
    public abstract class Bases
    {
        public string Description = "";
        public double BaseTime = 3000;
        protected double Multiplier = 1;
        public double CookingTime => BaseTime * Multiplier;


    }
    public class DeepPan : Bases
    {
        public DeepPan()
        {
            Description = "Deep Pan";
            Multiplier = 2;

        }
    }

    public class StuffedCrust : Bases
    {
        public StuffedCrust()
        {
            Description = "Stuffed Crust";
            Multiplier = 1.5;
        }
    }

    public class ThinCrispy : Bases
    {
        public ThinCrispy()
        {
            Description = "Thin and Crispy";
        }

    }

}