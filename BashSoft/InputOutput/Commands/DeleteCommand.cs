using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.InputOutput.Commands
{
    class DeleteCommand : Command
    {
        public DeleteCommand(string input, string[] data, IContentComparer judge, IDirectoryManager manager) : base(input, data, judge, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileDirName = this.Data[1];

            string path = SessionData.currentPath + "\\" + fileDirName;

            Console.WriteLine(path);

            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path);

                }
                catch (Exception e)
                {
                    OutputWriter.DisplayException(e.Message);
                }
            }
            else if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);

                }
                catch (Exception e)
                {
                    OutputWriter.DisplayException(e.Message);
                }
            }
                

            
        }
    }
}
