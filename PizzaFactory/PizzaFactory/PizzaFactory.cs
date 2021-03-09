using System;
using PizzaFactory.Services;
using System.Threading;

namespace PizzaFactory
{
    public class PizzaFactoryRunner
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IConfigurationService _configurationService;

        public PizzaFactoryRunner(ConsoleWriter consoleWriter, ConfigurationService configurationService)
        {
            _consoleWriter = consoleWriter;
            _configurationService = configurationService;
        }

        public void RunPizzaFactory()
        {
            var totalNumberPizzas = _configurationService.GetTotalNumberPizzas();
            for (int i = 0; i < totalNumberPizzas; i++)
            {
                Console.WriteLine(i + 1);
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
            var pizza = new Pizza(CreateRandomTopping(), CreateRandomBase());

            var totalPizzaCookingTime = (int)pizza.PizzaCookingTime;
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
