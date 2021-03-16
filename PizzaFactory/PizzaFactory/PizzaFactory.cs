using System;
using PizzaFactory.Services;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaFactory
{
    public class PizzaFactoryRunner
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConfigurationService _configurationService;
        private readonly IFileWriter _fileWriter;

        public PizzaFactoryRunner(IServiceProvider serviceProvider)
        {
            _consoleWriter = serviceProvider.GetService<IConsoleWriter>();
            _configurationService = serviceProvider.GetService<IConfigurationService>();
            _fileWriter = serviceProvider.GetService<IFileWriter>();
        }

        public void RunPizzaFactory()
        {
            var totalNumberPizzas = _configurationService.GetTotalNumberPizzas();

            if (totalNumberPizzas == 0)
            {
                _consoleWriter.WriteLine($"\nThe number of pizzas is { totalNumberPizzas }!!\n\n");
            }

            _consoleWriter.WriteLine($"\nWE ARE COOKING YOUR { totalNumberPizzas } PIZZAS!!\n\n");

            for (int i = 0; i < totalNumberPizzas; i++)
            {
                _consoleWriter.WriteLine((i + 1).ToString());
                CreateRandomPizza();
            }
        }

        public Topping CreateRandomTopping()
        {
            Topping[] toppings = { new HamMushroom((ConfigurationService)_configurationService),
                                    new Pepperoni((ConfigurationService)_configurationService),
                                    new Vegetable((ConfigurationService)_configurationService) };

            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];
        }
        
        public Base CreateRandomBase()
        {
            Base[] bases = { new ThinAndCrispy((ConfigurationService)_configurationService), 
                             new DeepPan((ConfigurationService)_configurationService),
                             new StuffedCrust((ConfigurationService)_configurationService) };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }

        public Pizza CreateRandomPizza()
        {
            var pizza = new Pizza();
            var randomTopping = CreateRandomTopping();
            var randomBase = CreateRandomBase();

            var pizzaDescription = pizza.GetPizzaDescription(randomTopping, randomBase);
            Console.WriteLine($"Cooking a { pizzaDescription } pizza...");

            _fileWriter.WritePizzaDescription(pizzaDescription);

            var totalPizzaCookingTime = (int)pizza.GetPizzaCookingTime(randomTopping, randomBase);
            var cookingInterval = (int)_configurationService.GetIntervalTime();

            _consoleWriter.WriteLine("Sleeping.....................zzzz\n");

            Thread.Sleep(totalPizzaCookingTime);
            _consoleWriter.WriteLine($"Pizza finished after { totalPizzaCookingTime } milliseconds.\n");

            Thread.Sleep(cookingInterval);
            _consoleWriter.WriteLine($"Time between pizzas: { cookingInterval } milliseconds, finished!!!!!!!!\n");

            return pizza;
        }

    }
}
