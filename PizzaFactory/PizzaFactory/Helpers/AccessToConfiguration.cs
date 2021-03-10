using System;
using Microsoft.Extensions.Configuration;

namespace PizzaFactory.Helpers
{
    public static class AccessToConfiguration
    {
        public static IConfiguration Configuration;

        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("Configuration.json").Build();

            return configuration;
        }
    }
}
