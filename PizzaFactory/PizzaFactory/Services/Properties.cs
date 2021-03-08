﻿using System;
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


    }
}
