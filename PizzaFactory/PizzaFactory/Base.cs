using PizzaFactory.Services;


namespace PizzaFactory
{
    public abstract class Base
    {
        protected IConfigurationService _configurationService;

        protected Base(ConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        public string BaseType { get; protected set; }
        public string Description { get; protected set; }
        public double TotalBaseTime { get; protected set; }
    }
    public class DeepPan : Base
    {
        public DeepPan(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            BaseType = "DeepPan";
            Description = "Deep Pan";
            TotalBaseTime = configurationService.CalculateTotalBaseTime(BaseType);
        }
    }

    public class StuffedCrust : Base
    {
        public StuffedCrust(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            BaseType = "StuffedCrust";
            Description = "Stuffed Crust";
            TotalBaseTime = configurationService.CalculateTotalBaseTime(BaseType);
        }
    }

    public class ThinAndCrispy : Base
    {
        public ThinAndCrispy(IConfigurationService configurationService)
            : base((ConfigurationService)configurationService)
        {
            BaseType = "ThinAndCrispy";
            Description = "Thin and Crispy";
            TotalBaseTime = configurationService.CalculateTotalBaseTime(BaseType);
        }
    }
}