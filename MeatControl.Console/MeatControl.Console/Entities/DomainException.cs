using System;
using System.Collections.Generic;
using System.Text;

namespace MeatControlConsole.Entities
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {
            
        }
    }
}
