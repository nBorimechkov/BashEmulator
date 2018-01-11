using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Exceptions
{
    class InvalidCommandException : Exception
    {
        public const string InvalidCommand = "The following command is invalid: ";

        public InvalidCommandException()
        {

        }
        public InvalidCommandException(string input)
            :base(input)
        {
            
        }
    }
}
