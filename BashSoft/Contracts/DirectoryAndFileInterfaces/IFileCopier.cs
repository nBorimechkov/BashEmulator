using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.Contracts
{
    public interface IFileCopier
    {
        void CopyFile(string sourcePath, string destinationPath);
    }
}
