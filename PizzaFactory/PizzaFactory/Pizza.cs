using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace PizzaFactory
{
    public class Pizza
    {
        private string _pizzaDescription;

        private double _pizzaCookingTime;


        public string PizzaDescription
        {
            get => _pizzaDescription;
            set => _pizzaDescription = value;
        }

        public double PizzaCookingTime
        {
            get => _pizzaCookingTime;
            set => _pizzaCookingTime = value;
        }

        public string GetPizzaDescription(Topping randomTopping, Base randomBase)
        {
            _pizzaDescription = randomTopping.Description + " " + randomBase.Description;
            return _pizzaDescription;
        }

        public double GetPizzaCookingTime(Topping randomTopping, Base randomBase)
        {
            _pizzaCookingTime = randomTopping.TotalToppingTime + randomBase.TotalBaseTime;
            return _pizzaCookingTime;
        }
    }

}
