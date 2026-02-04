using System.Globalization;
using System.Runtime.CompilerServices;

namespace MeatControlConsole.Entities
{
    internal class Meat
    {
        public int Id { get; private set; }
        public string Cut { get; set; }
        public double Price { get; set; }

        public Meat(int id, string cut, double price)
        {
            if (string.IsNullOrEmpty(cut))
                throw new DomainException("The meat needs to be of a certain type");


            if (price <= 0)
                throw new DomainException("The price of meat cannot be equal to or less than zero.");

            Id = id;
            Cut = cut;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id};{Cut};{Price.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
