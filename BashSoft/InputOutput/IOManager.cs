using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory()
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(SessionData.currentPath))
                {
                    int indexOfLastSlash = directory.LastIndexOf("\\");
                    string dirName = directory.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(dirName);
                }
                OutputWriter.WriteEmptyLine();

                foreach (var file in Directory.GetFiles(SessionData.currentPath)) 
                {
                    int indexOfLastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(fileName);
                }
                OutputWriter.WriteEmptyLine();
            }
            catch (UnauthorizedAccessException)
            {
                OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccess);
            }
        
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void DeleteDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + name;
            try
            {
                Directory.Delete(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectory(string path)
        {
            string currentPath = SessionData.currentPath;
            if (path == "..")
            {
                try
                {
                    int indexOfLastSlash = currentPath.LastIndexOf("\\");
                    string newPath = currentPath.Substring(0, indexOfLastSlash);
                    SessionData.currentPath = newPath;
                }
                catch (Exception ex)
                {
                    OutputWriter.DisplayException(ex.Message);
                }
            }
            // Absolute path
            else if (Path.IsPathRooted(path))
            {
                Console.WriteLine(path);
                if (!Directory.Exists(path))
                {
                    throw new InvalidPathException();
                }
                SessionData.currentPath = path;
            }
            // Relative path
            else 
            {
                currentPath += "\\" + path;
                if (!Directory.Exists(currentPath))
                {
                    throw new InvalidPathException();
                }
                SessionData.currentPath = currentPath;

            }
        }
    }
}
