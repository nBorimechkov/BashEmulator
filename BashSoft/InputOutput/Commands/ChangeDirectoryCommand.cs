using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;
using System.Collections.Generic;

namespace BashSoft
{
    internal class ChangeDirectoryCommand : Command
    {
        public ChangeDirectoryCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {
        }

        public override void Execute()
        {
            try
            {
                if (this.Data.Length == 2)
                {
                    string path = this.Data[1];
                    this.Manager.ChangeCurrentDirectory(path);
                }
                // special case for when a path contains whitespaces and is not parsed properly
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
                    throw new InvalidCommandException(this.Input);
                }
            }
            catch (InvalidPathException)
            {
                OutputWriter.DisplayException(InvalidPathException.InvalidPath);
            }
        }
    }
}