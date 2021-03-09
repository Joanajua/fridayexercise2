using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory
{
    public abstract class Toppings
    {
        public string Description = "";
        public string DescriptionPrint = "";
        public double ToppingCookingTime => Description.Length * 100;

    }

    public class HamMushroom : Toppings
    {
        public HamMushroom()
        {
            DescriptionPrint = "Ham & Mushrooms";
            Description = DescriptionPrint.Remove(3, 3);
        }
    }
    public class Pepperoni : Toppings
    {
        public Pepperoni()
        {
            Description = "Pepperoni";
            DescriptionPrint = Description;
        }
    }

    public class Vegetable : Toppings
    {
        public Vegetable()
        {
            Description = "Vegetable";
            DescriptionPrint = Description;
        }
    }
}

