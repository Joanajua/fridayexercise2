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

        public Toppings CreateRandomTopping()
        {
            Toppings[] toppings = { new HamMushroom(), new Pepperoni(), new Vegetable() };
            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];
        }
        
        public Base CreateRandomBase()
        {
            var hello = _configurationService;
            Base[] bases =
                    { new ThinAndCrispy((ConfigurationService)_configurationService), 
                        new DeepPan((ConfigurationService)_configurationService),
                        new StuffedCrust((ConfigurationService)_configurationService) };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }

        public Pizza CreateRandomPizza()
        {
            var newPizza = new Pizza(CreateRandomTopping(), CreateRandomBase());
            //Console.WriteLine($"Cooking a {newPizza.PizzaDescription} pizza...");

            TimeSpan intervale = TimeSpan.FromMilliseconds(newPizza.PizzaCookingTime);
            //intervale = intervale.Duration();

            double timeBetweenPizzas = 7400;
            TimeSpan cookingIntervale = TimeSpan.FromMilliseconds(timeBetweenPizzas);

            _consoleWriter.WriteLine("Sleeping.....................zzzz");

            Thread.Sleep(intervale);
            _consoleWriter.WriteLine($"Pizza finished after {intervale} seconds.\n");

            Thread.Sleep(cookingIntervale - intervale);
            _consoleWriter.WriteLine($"Time between pizzas: {cookingIntervale} finished!!!!!!!!\n");

            return newPizza;
        }

    }
}
