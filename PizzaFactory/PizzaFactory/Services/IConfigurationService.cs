using Microsoft.Extensions.Configuration;

namespace PizzaFactory.Services
{
    public interface IConfigurationService
    {
        int GetTotalNumberPizzas();
        double GetBaseCookingTime();
        double GetBaseMultiplier(string baseType);
        double GetToppingCookingTime();
        double GetIntervalTime();
        string GetFilePath();
        IConfiguration GetProperties();
    }
}
