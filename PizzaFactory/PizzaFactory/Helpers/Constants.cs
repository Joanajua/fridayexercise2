using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace PizzaFactory.Services
{
    public class Properties
    {
        public string BaseCookingTime { get; set; }
        public string TimePerLetterTopping { get; set; }
        public string TotalNumberPizzas { get; set; }
        public string CookingInterval { get; set; }
        public BaseMultiplier BaseMultiplier { get; set; }
    }

    public class BaseMultiplier
    {
        public string DeepPan { get; set; }
        public string StuffedCrust { get; set; }
        public string ThinAndCrispy { get; set; }
    }
}