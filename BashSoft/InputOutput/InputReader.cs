using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    class InputReader : IReader
    {
        private IInterpreter interpreter;
        private const string endCommand = "quit";

        public InputReader(IInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            string input = string.Empty;  
               
            while (input != endCommand)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                input = Console.ReadLine();
                input = input.Trim();
                this.interpreter.InterpretCommand(input);
            }
        }
    }
}
