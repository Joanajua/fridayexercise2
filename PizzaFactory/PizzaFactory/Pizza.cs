using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory
{
    public class Pizza
    {

        //public double PizzaTime { get; set; }
        public string PizzaDescription { get; set; }
        public double PizzaCookingTime { get; set; }
        //public Bases PizzaBase { get; set; }
        //public Toppings PizzaTopping { get; set; }

        //public Pizza()
        //{

        //}

        public Pizza(Toppings randomTopping, Bases randomBase)
        {
            PizzaDescription = randomTopping.DescriptionPrint + " " + randomBase.Description;
            PizzaCookingTime = randomTopping.CookingTime + randomBase.CookingTime;
            Console.WriteLine($"Cooking a {PizzaDescription} pizza...");

        }

    }

}
