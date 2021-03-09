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
            //IServiceCollection services = new ServiceCollection();
            //ConfigureServices(services);
            var consoleWriter = new ConsoleWriter();
            var configurationService = new ConfigurationService(consoleWriter, config);
            var pizzaFactoryRunner = new PizzaFactoryRunner(consoleWriter, configurationService);

            pizzaFactoryRunner.RunPizzaFactory();
        }

        static ServiceProvider SetupDependencyInjection()
        {
            return new ServiceCollection()
                .AddSingleton<IConsoleWriter, ConsoleWriter>()
                .BuildServiceProvider();
        }

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddSingleton<IConsoleWriter, ConsoleWriter>();
        //    services.AddSingleton<IConfigurationService, ConfigurationService>();
        //}
    }
}
