using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaFactory.Services
{
    public interface IConfigurationService
    {
        int GetTotalNumberPizzas();

        double GetBaseCookingTime();

        double GetBaseMultiplier(string baseType);

        double CalculateTotalBaseTime(string baseType);
    }
}
