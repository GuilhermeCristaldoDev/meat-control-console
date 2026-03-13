using System;
using System.Collections.Generic;
using System.Text;

namespace MeatControlConsole.Entities
{
    internal class MeatSummary
    {
        public int TotalMeats { get; set; }
        public double TotalValue { get; set; }

        public void CalculateSummary(IEnumerable<Meat> meats)
        {
            TotalMeats = meats.Count();
            TotalValue = meats.Sum(m => m.Price);
        }
    }

}
