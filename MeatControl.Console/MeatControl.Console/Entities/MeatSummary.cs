using System;
using System.Collections.Generic;
using System.Text;

namespace MeatControlConsole.Entities
{
    internal class MeatSummary
    {
        public int TotalMeats { get; private set; }
        public decimal TotalValue { get; private set; }

        public void CalculateSummary(IEnumerable<Meat> meats)
        {
            TotalMeats = meats.Count();
            TotalValue = meats.Sum(m => m.Price);
        }
    }

}
