using System;
using System.Collections.Generic;
using System.Text;

namespace MeatControlConsole.Entities
{
    internal class MeatSummary
    {
        public int TotalMeats { get; set; }
        public double TotalValue { get; set; }

        public MeatSummary(int totalMeats, double totalValue)
        {
            TotalMeats = totalMeats;
            TotalValue = totalValue;
        }
    }

}
