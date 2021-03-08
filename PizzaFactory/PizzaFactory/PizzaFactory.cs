using System;
using Microsoft.Extensions.DependencyInjection;
using PizzaFactory.Services;
using System.Threading;

namespace PizzaFactory
{
    public class PizzaFactoryRunner
    {
        private readonly IConsoleWriter _consoleWriter;

        public PizzaFactoryRunner(IServiceProvider serviceProvider)
        {
            _consoleWriter = serviceProvider.GetService<IConsoleWriter>();
        }

        public int AskingNumberPizzas()
        {

            var minNumberPizzas = 50;

            Console.Write("Input a number of pizzas, the minimum order is 50 and the maximum is 100: ");
            string inputPizzas = Console.ReadLine();

            var tryingToParseInput = int.TryParse(inputPizzas, out int inputnumberPizzas);

            if (tryingToParseInput)
            {
                if (inputnumberPizzas >= minNumberPizzas && inputnumberPizzas <= 100)
                {
                    Console.WriteLine($"\n\nWE ARE COOKING YOUR {inputnumberPizzas} PIZZAS!!\n\n");

                    return inputnumberPizzas;

                }

                do
                {
                    Console.Write("Sorry, enter a number between 100 and 50: ");
                    inputPizzas = Console.ReadLine();
                    tryingToParseInput = int.TryParse(inputPizzas, out inputnumberPizzas);

                }
                while (inputnumberPizzas < minNumberPizzas || inputnumberPizzas > 100);

                Console.WriteLine($"\n\nWE ARE COOKING YOUR  {inputnumberPizzas} PIZZAS!!\n\n");

                return inputnumberPizzas;

            }
           
            Console.Write("Sorry, the number you entered is not valid, chose a number higher than 50 and lower than 101: ");
            return 0;
        }

        public void RunPizzaFactory(int inputnumberPizzas)
        {
            for (int i = 0; i< inputnumberPizzas; i++)
            {
                Console.WriteLine(i + 1);
                CreateRandomPizza();

            }
        }


        public Toppings CreateRandomTopping()
        {
            //Toppings pizzaTopping = null;

            Toppings[] toppings = new Toppings[]
            {
                new HamMushroom(), new Pepperoni(), new Vegetable()
            };

            var random = new Random();
            var randomTopping = random.Next() % toppings.Length;

            return toppings[randomTopping];

        }

        public Bases CreateRandomBase()
        {
            //Bases pizzabase = null;

            Bases[] bases = new Bases[]
            {
                new ThinCrispy(), new DeepPan(), new StuffedCrust()
            };

            var random = new Random();
            var randomBase = random.Next() % bases.Length;
            //Console.WriteLine($"{bases[randomBase].Description} pizza.");
            return bases[randomBase];

        }



        //public Pizza CreateRandomPizza() => new Pizza(CreateRandomTopping(), CreateRandomBase());

        public Pizza CreateRandomPizza()
        {
            
            Pizza newPizza = new Pizza(CreateRandomTopping(), CreateRandomBase());
            //Console.WriteLine($"Cooking a {newPizza.PizzaDescription} pizza...");

            TimeSpan intervale = TimeSpan.FromMilliseconds(newPizza.PizzaCookingTime);
            //intervale = intervale.Duration();

            double timeBetweenPizzas = 7400;
            TimeSpan cookingIntervale = TimeSpan.FromMilliseconds(timeBetweenPizzas);

            Console.WriteLine("Sleeping.....................zzzz");

            Thread.Sleep(intervale);
            Console.WriteLine($"Pizza finished after  {intervale} seconds.\n");

            Thread.Sleep(cookingIntervale - intervale);
            Console.WriteLine($"Time between pizzas: {cookingIntervale} finished!!!!!!!!\n");

            return newPizza;

        }

    }
}
