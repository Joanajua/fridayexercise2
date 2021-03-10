using System;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using PizzaFactory.Helpers;
using PizzaFactory.Services;

namespace PizzaFactory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AccessToConfiguration.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public static void RunApplication()
        {
            var consoleWriter = new ConsoleWriter();
            var configurationService = new ConfigurationService();

            var pizzaFactoryRunner = new PizzaFactoryRunner(consoleWriter, configurationService);

            pizzaFactoryRunner.RunPizzaFactory();
        }
    }
}
