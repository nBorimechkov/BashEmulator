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
        private Tester judge;
        private IDirectoryManager manager;
        private StudentRepository repository;

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

        protected Tester Judge
        {
            get { return this.judge; }
        }

        protected IDirectoryManager Manager
        {
            get { return this.manager; }
        }

        protected StudentRepository Repository
        {
            get { return this.repository; }
        }

        public Command(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.manager = manager;
        }

        public abstract void Execute();
    }
}
