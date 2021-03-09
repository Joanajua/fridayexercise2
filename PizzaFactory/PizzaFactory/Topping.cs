using PizzaFactory.Services;

namespace PizzaFactory
{
    public abstract class Topping
    {
        protected IConfigurationService _configurationService;
        protected Topping(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string Description { get; protected set; }
        public double TotalToppingTime { get; protected set; }
    }

    public class HamMushroom : Topping
    {
        public HamMushroom(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            Description = "Ham and Mushrooms";
            TotalToppingTime = configurationService.CalculateTotalToppingTime(Description);
        }
    }
    public class Pepperoni : Topping
    {
        public Pepperoni(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            Description = "Pepperoni";
            TotalToppingTime = configurationService.CalculateTotalToppingTime(Description);
        }
    }

    public class Vegetable : Topping
    {
        public Vegetable(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            Description = "Vegetable";
            TotalToppingTime = configurationService.CalculateTotalToppingTime(Description);
        }
    }
}

