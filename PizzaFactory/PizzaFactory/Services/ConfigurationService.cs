using System;
using Microsoft.Extensions.Configuration;
using PizzaFactory.Helpers;

namespace PizzaFactory.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public int GetTotalNumberPizzas()
        {
            var configSection = GetProperties();
            var numberPizzasConfig = configSection.Get<Properties>().TotalNumberPizzas;
            var isNumberPizzasParsed = int.TryParse(numberPizzasConfig, out int totalNumberPizzas);

            if (!isNumberPizzasParsed)
            {
                totalNumberPizzas = 0;
                return totalNumberPizzas;
            }
            return totalNumberPizzas;
        }

        public double GetBaseCookingTime()
        {
            var configSection = GetProperties();
            var baseCookingTimeConfig = configSection.Get<Properties>().BaseCookingTime;
            var isBaseCookingTimeParsed = double.TryParse(baseCookingTimeConfig, out double baseCookingTime);

            if (!isBaseCookingTimeParsed)
            {
                baseCookingTime = 0;
                return baseCookingTime;
            }
            return baseCookingTime;
        }

        public double GetBaseMultiplier(string baseType)
        {
            var configSection = GetProperties();
            var baseMultiplierConfig = "";

            if (baseType == "DeepPan")
            { 
                baseMultiplierConfig = configSection.Get<Properties>().BaseMultiplier.DeepPan;
            }

            if (baseType == "StuffedCrust")
            {
                baseMultiplierConfig = configSection.Get<Properties>().BaseMultiplier.StuffedCrust;
            }

            if (baseType == "ThinAndCrispy")
            {
                baseMultiplierConfig = configSection.Get<Properties>().BaseMultiplier.ThinAndCrispy;
            }
            var isBaseMultiplierParsed = double.TryParse(baseMultiplierConfig, out double baseMultiplier);

            if (!isBaseMultiplierParsed)
            {
                baseMultiplier = 1;
                return baseMultiplier;
            }
            return baseMultiplier;
        }

        public double GetToppingCookingTime()
        {
            var configSection = GetProperties();
            var timePerLetterToppingConfig = configSection.Get<Properties>().TimePerToppingLetter;
            var isTimePerLetterToppingParsed = double.TryParse(timePerLetterToppingConfig, out double timePerLetterTopping);

            if (!isTimePerLetterToppingParsed)
            {
                timePerLetterTopping = 0;
                return timePerLetterTopping;
            }
            return timePerLetterTopping;
        }

        public double CalculateTotalToppingTime(string description)
        {
            description = description.Replace(" ", String.Empty);
            var timePerLetterTopping = GetToppingCookingTime();

            var totalToppingTime = timePerLetterTopping * description.Length;

            return totalToppingTime;
        }

        public double GetIntervalTime()
        {
            var configSection = GetProperties();
            var cookingIntervalConfig = configSection.Get<Properties>().CookingInterval;
            var isCookingIntervalParsed = double.TryParse(cookingIntervalConfig, out double cookingInterval);

            if (!isCookingIntervalParsed)
            {
                cookingInterval = 0;
                return cookingInterval;
            }
            return cookingInterval;
        }

        public string GetFilePath()
        {
            var configSection = GetProperties();
            var filePath = configSection.Get<Properties>().FilePath;

            return filePath;
        }

        public IConfiguration GetProperties()
        {
            var configSection = ConfigurationManager.Configuration.GetSection(nameof(Properties));
            return configSection;
        }
    }

}
