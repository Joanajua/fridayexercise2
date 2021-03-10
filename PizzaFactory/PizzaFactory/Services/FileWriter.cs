using System;
using System.IO;

namespace PizzaFactory.Services
{
    public class FileWriter : IFileWriter
    {
        private readonly IConfigurationService _configuration;

        public FileWriter(IConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public void WritePizzaDescription(string pizzaDescription)
        {
            var filePathConfig = _configuration.GetFilePath();
            //var filePathConfig = "pizzaFactory.txt";

            var filePath = (AppDomain.CurrentDomain.BaseDirectory + @"\" + filePathConfig);

            if (!File.Exists(filePath))
            {
                // Create a file to write to.
                using (StreamWriter streamWriter = File.CreateText(filePath))
                {
                    streamWriter.WriteLine(pizzaDescription);
                }
            }

            // If file already exist add line.
            using (StreamWriter streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine(pizzaDescription);
            }
        }
    }
}