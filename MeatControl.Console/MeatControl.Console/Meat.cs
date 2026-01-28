using System.Globalization;

namespace MeatControl.Console
{
    internal class Meat
    {
        public int Id { get; private set; }
        public string Cut { get; set; }
        public double Price { get; set; }

        public Meat(int id, string cut, double price)
        {
            Id = id;
            Cut = cut;
            Price = price;
        }

        public override string ToString ()
        {
            return $"{Id};{Cut};{Price.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
