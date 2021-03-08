using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System;
using Microsoft.Extensions.Configuration;

namespace PizzaFactory
{
    class Program
    {
        public static int inputnumberPizzas { get; set; }

        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Configuration.json").Build();

           
            var serviceProvider = SetupDependencyInjection();
            
            var pizzaFactoryRunner = new PizzaFactoryRunner(serviceProvider, config);
            var inputnumberPizzas = pizzaFactoryRunner.AskingNumberPizzas();

            pizzaFactoryRunner.RunPizzaFactory(inputnumberPizzas);
        }
        
        static ServiceProvider SetupDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }

    }
}
