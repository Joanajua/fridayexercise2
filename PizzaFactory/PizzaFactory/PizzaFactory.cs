using System;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace PizzaFactory
{
    public class PizzaFactoryRunner
    {
        private readonly IConsoleWriter _consoleWriter;
        //private readonly IConfigurationRoot _config;
        private readonly ConfigurationService _configurationService;

        public PizzaFactoryRunner(IServiceProvider serviceProvider, ConfigurationService configurationService)
        {
            _consoleWriter = serviceProvider.GetService<IConsoleWriter>();
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
            Base[] bases =
                { new ThinAndCrispy(_configurationService), new DeepPan(_configurationService), new StuffedCrust(_configurationService) };
            var random = new Random();
            var randomBase = random.Next() % bases.Length;

            return bases[randomBase];
        }



        //public Pizza CreateRandomPizza() => new Pizza(CreateRandomTopping(), CreateRandomBase());

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
