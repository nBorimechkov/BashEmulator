using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Exceptions
{
    class InvalidPathException : Exception
    {
        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";

        public InvalidPathException()
        {

        }

        public InvalidPathException(string message)
            :base(InvalidPath)
        {

        }
    }
}
