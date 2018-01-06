using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
using System.Diagnostics;
using BashSoft.Contracts;

namespace BashSoft.InputOutput.Commands
{
    class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager)
            :base (input, data, judge, repository, manager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException();
            }
            string fileName = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + fileName);
        }
    }
}
