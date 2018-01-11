using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
using BashSoft.Contracts;

namespace BashSoft.InputOutput.Commands
{
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;
        
        private IDirectoryManager manager;

        public string Input
        {
            get { return this.input; }
            private set
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

        public string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }

        protected IDirectoryManager Manager
        {
            get { return this.manager; }
        }

        public Command(string input, string[] data, IDirectoryManager manager)
        {
            this.Input = input;
            this.Data = data;
            this.manager = manager;
        }

        public abstract void Execute();
    }
}
