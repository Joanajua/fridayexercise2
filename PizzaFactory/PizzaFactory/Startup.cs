using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;

namespace PizzaFactory
{
    public class Startup
    {
        public static void RunApplication()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Configuration.json").Build();

            var consoleWriter = new ConsoleWriter();
            var configurationService = new ConfigurationService(consoleWriter, config);

            var pizzaFactoryRunner = new PizzaFactoryRunner(consoleWriter, configurationService);

            pizzaFactoryRunner.RunPizzaFactory();
        }
    }
}
