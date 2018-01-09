using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IInterpreter currentInterpreter = new CommandInterpreter(tester, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
