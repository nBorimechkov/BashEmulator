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
        public OpenFileCommand(string input, string[] data, IContentComparer judge, IDirectoryManager manager)
            :base (input, data, judge, manager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }
            string fileName = this.Data[1];
            try
            {
                Process.Start(SessionData.currentPath + "\\" + fileName);
            }
            catch (ArgumentException ex)
            {
                OutputWriter.DisplayException(ex.Message);
                
            }
        }
    }
}
