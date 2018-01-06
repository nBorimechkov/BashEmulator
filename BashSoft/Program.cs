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
            IDatabase repo = new StudentRepository(new RepositoryFilter(), new RepositorySorter());
            IInterpreter currentInterpreter = new CommandInterpreter(tester, ioManager, repo);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
