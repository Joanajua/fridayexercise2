using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace PizzaFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.RunApplication();
        }
    }
}
