//using PizzaFactory.Services;
//using System;
//using Xunit;

//namespace PizzaFactory.Tests
//{
//    public class UnitTest1
//    {
//        private IServiceProvider serviceProvider;

//        [Fact]
//        public void Test_AskingNumberPizzas()
//        {
//            // Arrange
//            var minNumberPizzas = 50;

//            PizzaFactoryRunner sut = new PizzaFactoryRunner(serviceProvider);
           

//            Console.Write("Input a number of pizzas, the minimum order is 50 and the maximum is 100: ");

//            // Act

//            string inputPizzas = Console.ReadLine();

//            var tryingToParseInput = int.TryParse(inputPizzas, out int inputnumberPizzas);

//            if (tryingToParseInput)
//            {
//                if (inputnumberPizzas >= minNumberPizzas && inputnumberPizzas <= 100)
//                {
//                    Console.WriteLine($"\n\nWE ARE COOKING YOUR {inputnumberPizzas} PIZZAS!!\n\n");

//                    return inputnumberPizzas;

//                }

//                else
//                {

//                    do
//                    {
//                        Console.Write("Sorry, enter a number between 100 and 50: ");
//                        inputPizzas = Console.ReadLine();
//                        tryingToParseInput = int.TryParse(inputPizzas, out inputnumberPizzas);

//                    }
//                    while (inputnumberPizzas < minNumberPizzas || inputnumberPizzas > 100);

//                    Console.WriteLine($"\n\nWE ARE COOKING YOUR  {inputnumberPizzas} PIZZAS!!\n\n");

//                    return inputnumberPizzas;
//                }

//                // Assert
//                Assert.Equal(4, output);
//        }
//    }
//}
