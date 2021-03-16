using PizzaFactory.Services;

namespace PizzaFactory
{
    public class Base
    {
        private readonly IConfigurationService _configurationService;
        public Base(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string BaseType { get; protected set; }
        public string Description { get; protected set; }
        public double TotalBaseTime { get; protected set; }

        public double CalculateTotalBaseTime(string baseType)
        {
            double totalBaseTime = 0;

            if (string.IsNullOrEmpty(baseType))
            {
                return totalBaseTime;
            }

            var baseCookingTime = _configurationService.GetBaseCookingTime();
            var baseMultiplier = _configurationService.GetBaseMultiplier(baseType);
            totalBaseTime = baseCookingTime * baseMultiplier;

            return totalBaseTime;
        }
    }

    public class DeepPan : Base
    {
        public DeepPan(IConfigurationService configurationService)
            : base(configurationService)
        {
            BaseType = "DeepPan";
            Description = "Deep Pan";
            TotalBaseTime = CalculateTotalBaseTime(BaseType);
        }
    }

    public class StuffedCrust : Base
    {
        public StuffedCrust(IConfigurationService configurationService)
            : base(configurationService)
        {
            BaseType = "StuffedCrust";
            Description = "Stuffed Crust";
            TotalBaseTime = CalculateTotalBaseTime(BaseType);
        }
    }

    public class ThinAndCrispy : Base
    {
        public ThinAndCrispy(IConfigurationService configurationService)
            : base(configurationService)
        {
            BaseType = "ThinAndCrispy";
            Description = "Thin and Crispy";
            TotalBaseTime = CalculateTotalBaseTime(BaseType);
        }
    }
}