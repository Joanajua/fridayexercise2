using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace PizzaFactory.Services
{
    public class ConfigurationService
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConfigurationRoot _config;

        public ConfigurationService(IServiceProvider serviceProvider, IConfigurationRoot config)
        {
            _consoleWriter = serviceProvider.GetService<IConsoleWriter>();
            _config = config;
        }

        public int GetTotalNumberPizzas()
        {
            var configSection = _config.GetSection(nameof(Properties));
            var numberPizzasConfig = configSection.Get<Properties>().TotalNumberPizzas;

            var isNumberPizzasParsed = int.TryParse(numberPizzasConfig, out int totalNumberPizzas);

            if (!isNumberPizzasParsed)
            {
                totalNumberPizzas = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");
                break;
            }

            _consoleWriter.WriteLine($"\n\nWE ARE COOKING YOUR {totalNumberPizzas} PIZZAS!!\n\n");

            return totalNumberPizzas;
        }

        private int GetBaseCookingTime()
        {
            var configSection = _config.GetSection(nameof(Properties));
            var baseCookingTimeConfig = configSection.Get<Properties>().BaseCookingTime;

            var isBaseCookingTimeParsed = int.TryParse(baseCookingTimeConfig, out int baseCookingTime);

            if (!isBaseCookingTimeParsed)
            {
                baseCookingTime = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");

                return baseCookingTime;
            }

            return baseCookingTime;
        }

        private int GetBaseMultiplier(string baseType)
        {
            var configSection = _config.GetSection(nameof(Properties));

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

            var isBaseMultiplierParsed = int.TryParse(baseMultiplierConfig, out int baseMultiplier);

            if (!isBaseMultiplierParsed)
            {
                baseMultiplier = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");

                return baseMultiplier;
            }

            return baseMultiplier;
        }

        public int CalculateTotalBaseTime(string baseType)
        {
            var baseCookingTime = GetBaseCookingTime();
            var baseMultiplier = GetBaseMultiplier(baseType);
            var totalBaseTime = baseCookingTime * baseMultiplier;

            return totalBaseTime;
        }
    }
}
