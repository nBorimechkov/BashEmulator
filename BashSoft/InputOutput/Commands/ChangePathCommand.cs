using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;
using System.Collections.Generic;

namespace BashSoft
{
    internal class ChangePathCommand : Command
    {
        public ChangePathCommand(string input, string[] data, IContentComparer judge, IDirectoryManager manager) : base(input, data, judge, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string path = this.Data[1];
                this.Manager.ChangeCurrentDirectory(path);
            }
            // special case for when a path has whitespaces and is not parsed properly
            else if (this.Data.Length > 2)
            {
                IList<string> absolutePath = new List<string>();
                for (int i = 1; i < this.Data.Length; i++)
                {
                    absolutePath.Add(this.Data[i]);
                }
                string finalPath = string.Join(" ", absolutePath);
                this.Manager.ChangeCurrentDirectory(finalPath);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(this.Data.Length.ToString());
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}