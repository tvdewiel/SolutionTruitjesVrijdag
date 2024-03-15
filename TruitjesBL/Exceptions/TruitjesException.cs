using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruitjesBL.Exceptions
{
    public class TruitjesException : Exception
    {
        public TruitjesException(string? message) : base(message)
        {
        }

        public TruitjesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
