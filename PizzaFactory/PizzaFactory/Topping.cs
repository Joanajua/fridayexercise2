using System;
using PizzaFactory.Services;
namespace PizzaFactory
{
    public class Topping
    {
        private readonly IConfigurationService _configurationService;
        public Topping(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string Description { get; protected set; }
        public double TotalToppingTime { get; protected set; }

        public double CalculateTotalToppingTime(string description)
        {
            double totalToppingTime = 0;

            if (string.IsNullOrEmpty(description))
            {
                return totalToppingTime;
            }

            description = description.Replace(" ", String.Empty);

            var timePerLetterTopping = _configurationService.GetToppingCookingTime();

            totalToppingTime = timePerLetterTopping * description.Length;

            return totalToppingTime;
        }
    }

    public class HamMushroom : Topping
    {
        public HamMushroom(IConfigurationService configurationService)
            : base(configurationService)
        {
            Description = "Ham and Mushrooms";
            TotalToppingTime = CalculateTotalToppingTime(Description);
        }
    }
    public class Pepperoni : Topping
    {
        public Pepperoni(IConfigurationService configurationService)
            : base(configurationService)
        {
            Description = "Pepperoni";
            TotalToppingTime = CalculateTotalToppingTime(Description);
        }
    }

    public class Vegetable : Topping
    {
        public Vegetable(IConfigurationService configurationService)
            : base(configurationService)
        {
            Description = "Vegetable";
            TotalToppingTime = CalculateTotalToppingTime(Description);
        }
    }
}

