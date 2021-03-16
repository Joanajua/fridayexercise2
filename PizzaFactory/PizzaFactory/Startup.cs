using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;

namespace PizzaFactory
{
    public class Startup
    {
        public static void RunApplication()
        {
            var service = SetupDependencyInjection();

            var pizzaFactoryRunner = new PizzaFactoryRunner(service);

            pizzaFactoryRunner.RunPizzaFactory();
        }

        static ServiceProvider SetupDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleWriter, ConsoleWriter>()
                .AddSingleton<IConfigurationService, ConfigurationService>()
                .AddSingleton<IFileWriter, FileWriter>()
                .BuildServiceProvider();
        }
    }
}
