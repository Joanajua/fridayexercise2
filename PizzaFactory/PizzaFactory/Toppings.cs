namespace PizzaFactory
{
    public abstract class Toppings
    {
        public string Description { get; protected set; }

        public double TotalToppingTime { get; protected set; }

        public double ToppingCookingTime => Description.Length * 100;

    }

    public class HamMushroom : Toppings
    {
        public HamMushroom() => Description = "Ham and Mushrooms";
    }
    public class Pepperoni : Toppings
    {
        public Pepperoni() => Description = "Pepperoni";
    }

    public class Vegetable : Toppings
    {
        public Vegetable() => Description = "Vegetable";
    }
}

