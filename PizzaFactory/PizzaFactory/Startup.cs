using Microsoft.Extensions.Configuration;
using PizzaFactory.Helpers;
using PizzaFactory.Services;

namespace PizzaFactory
{
    public class Startup
    {
        public static void RunApplication()
        {
            var consoleWriter = new ConsoleWriter();
            var configurationService = new ConfigurationService();
            var fileWriter = new FileWriter(configurationService);

            var pizzaFactoryRunner = new PizzaFactoryRunner(consoleWriter, configurationService, fileWriter);

            pizzaFactoryRunner.RunPizzaFactory();
        }
    }
}
