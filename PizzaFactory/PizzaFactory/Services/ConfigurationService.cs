using Microsoft.Extensions.Configuration;

namespace PizzaFactory.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConfigurationRoot _config;

        public ConfigurationService(ConsoleWriter consoleWriter, IConfigurationRoot config)
        {
            _consoleWriter = consoleWriter;
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
            }

            _consoleWriter.WriteLine($"\n\nWE ARE COOKING YOUR {totalNumberPizzas} PIZZAS!!\n\n");

            return totalNumberPizzas;
        }

        public double GetBaseCookingTime()
        {
            var configSection = _config.GetSection(nameof(Properties));
            var baseCookingTimeConfig = configSection.Get<Properties>().BaseCookingTime;

            var isBaseCookingTimeParsed = double.TryParse(baseCookingTimeConfig, out double baseCookingTime);

            if (!isBaseCookingTimeParsed)
            {
                baseCookingTime = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");

                return baseCookingTime;
            }

            return baseCookingTime;
        }

        public double GetBaseMultiplier(string baseType)
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

            var isBaseMultiplierParsed = double.TryParse(baseMultiplierConfig, out double baseMultiplier);

            if (!isBaseMultiplierParsed)
            {
                baseMultiplier = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");

                //TODO PUT A CONSOLO.READKEY() TO STOP EXECUTION OF THE PROGRAM
                return baseMultiplier;
            }

            return baseMultiplier;
        }

        public double CalculateTotalBaseTime(string baseType)
        {
            var baseCookingTime = GetBaseCookingTime();
            var baseMultiplier = GetBaseMultiplier(baseType);
            var totalBaseTime = baseCookingTime * baseMultiplier;

            return totalBaseTime;
        }

        public double GetToppingCookingTime( string description)
        {
            var configSection = _config.GetSection(nameof(Properties));
            var timePerLetterToppingConfig = configSection.Get<Properties>().TimePerLetterTopping;

            var isBaseCookingTimeParsed = double.TryParse(timePerLetterToppingConfig, out double baseCookingTime);

            if (!isBaseCookingTimeParsed)
            {
                baseCookingTime = 0;
                _consoleWriter.WriteLine($"\n\nWE ARE UNABLE TO COOK YOUR PIZZAS, PLEASE RESTART THE APPLICATION!!\n\n");

                return baseCookingTime;
            }

            return baseCookingTime;
        }
    }
}
