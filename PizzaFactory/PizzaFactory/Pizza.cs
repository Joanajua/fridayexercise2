using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory
{
    public class Pizza
    {
        public string PizzaDescription { get; set; }
        public double PizzaCookingTime { get; set; }
        
        public Pizza(Topping randomTopping, Base randomBase)
        {
            PizzaDescription = randomTopping.Description + " " + randomBase.Description;
            PizzaCookingTime = randomTopping.TotalToppingTime + randomBase.TotalBaseTime;
            Console.WriteLine($"Cooking a { PizzaDescription } pizza...");
        }
    }

}
