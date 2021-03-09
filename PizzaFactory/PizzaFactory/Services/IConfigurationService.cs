using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory.Services
{
    public interface IConfigurationService
    {
        int GetTotalNumberPizzas();
        double CalculateTotalBaseTime(string baseType);
        double GetIntervalTime();
        double CalculateTotalToppingTime(string description);
    }
}
