namespace MeatControl.Console
{
    internal class Meat
    {
        public int Id { get; private set; }
        public string Cut { get; set; }
        public double Price { get; set; }

        public Meat(string cut, double price)
        {
            Cut = cut;
            Price = price;
        }
    }
}
