using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Exceptions
{
    class InvalidStringException : Exception
    {
        public const string NullOrEmptyValue = "The value of the variable cannot be null or empty.";

        public InvalidStringException()
        {

        }

        public InvalidStringException(string message)
            :base(message)
        {

        }
    }
}
