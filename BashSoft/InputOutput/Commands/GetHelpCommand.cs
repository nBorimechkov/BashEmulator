using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.InputOutput.Commands
{
    class GetHelpCommand : Command
    {
        public GetHelpCommand(string input, string[] data, IDirectoryManager manager) 
            : base(input, data, manager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }
            this.DisplayHelp();
        }

        private void DisplayHelp()
        {
            OutputWriter.WriteMessageOnNewLine("traverse directory -    ls");
            OutputWriter.WriteMessageOnNewLine("change directory -      cd {..}/{relative or absolute path}");
            OutputWriter.WriteMessageOnNewLine("create directory -      mkdir {folder name} ");
            OutputWriter.WriteMessageOnNewLine("create file -           mkfile {file name}  ");
            OutputWriter.WriteMessageOnNewLine("open file -             open {file name}  ");
            OutputWriter.WriteMessageOnNewLine("copy file -             cp {source path} {destination path}  ");
            OutputWriter.WriteMessageOnNewLine("move directory/file -   mv {source path} {destination path}");
            OutputWriter.WriteMessageOnNewLine("remove directory/file - rm {name}  ");
            OutputWriter.WriteMessageOnNewLine("get help –              help");
            OutputWriter.WriteEmptyLine();
        }
    }
}
