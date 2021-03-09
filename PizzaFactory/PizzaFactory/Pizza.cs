using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory
{
    public class Pizza
    {
        public string PizzaDescription { get; set; }
        public double PizzaCookingTime { get; set; }
        
        public Pizza(Toppings randomTopping, Base randomBase)
        {
            PizzaDescription = randomTopping.DescriptionPrint + " " + randomBase.Description;
            PizzaCookingTime = randomTopping.ToppingCookingTime + randomBase.TotalBaseTime;
            Console.WriteLine($"Cooking a {PizzaDescription} pizza...");
        }
    }

}
