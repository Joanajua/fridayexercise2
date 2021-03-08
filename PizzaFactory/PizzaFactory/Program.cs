using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System;
using System.Threading;

namespace PizzaFactory
{
    class Program
    {
        public static int inputnumberPizzas { get; set; }

        static void Main(string[] args)
        {
            var serviceProvider = SetupDependencyInjection();
            
            var pizzaFactoryRunner = new PizzaFactoryRunner(serviceProvider);
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
