using MeatControlConsole.Entities.Exceptions;
using System.Globalization;
using MeatControlConsole.Entities.Enums;

namespace MeatControlConsole.Entities
{
    internal class Meat
    {
        public int Id { get; private set; }

        public MeatCut MeatCut;
        public double Price { get; set; }

        public Meat(int id, MeatCut cut, double price)
        {
 
            if (price <= 0)
                throw new DomainException("The price of meat cannot be equal to or less than zero.");

            Id = id;
            MeatCut = cut;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Id} - {MeatCut} : {Price.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }
}
