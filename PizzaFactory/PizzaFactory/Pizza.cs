namespace PizzaFactory
{
    public class Pizza
    {
        private string _pizzaDescription;

        private double _pizzaCookingTime;

        public Pizza()
        {
            PizzaDescription = _pizzaDescription;
            PizzaCookingTime = _pizzaCookingTime;
        }

        public string PizzaDescription { get; set; }

        public double PizzaCookingTime { get; set; }

        public string GetPizzaDescription(Topping randomTopping, Base randomBase)
        {
            _pizzaDescription = randomTopping.Description + " " + randomBase.Description;
            return _pizzaDescription;
        }

        public double GetPizzaCookingTime(Topping randomTopping, Base randomBase)
        {
            _pizzaCookingTime = randomTopping.TotalToppingTime + randomBase.TotalBaseTime;
            return _pizzaCookingTime;
        }
    }

}
