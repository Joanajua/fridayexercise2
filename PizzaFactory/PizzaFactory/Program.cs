using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System;
using Microsoft.Extensions.Configuration;

namespace PizzaFactory
{
    class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Configuration.json").Build();

            var serviceProvider = SetupDependencyInjection();
            
            var pizzaFactoryRunner = new PizzaFactoryRunner(serviceProvider, config);

            pizzaFactoryRunner.RunPizzaFactory();
        }
        
        static ServiceProvider SetupDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }

    }
}
