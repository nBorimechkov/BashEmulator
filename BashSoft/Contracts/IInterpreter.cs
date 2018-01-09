using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Contracts
{
    interface IInterpreter
    {
        void InterpretCommand(string command);
    }
}
