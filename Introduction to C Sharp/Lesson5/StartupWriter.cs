using System;
using System.IO;
using Lesson5.Interfaces;

namespace Lesson5
{
    class StartupWriter : IWriter
    {
        readonly string _path;
        public StartupWriter(string fileName)
        {
            _path = Directory.GetCurrentDirectory() + "\\" + fileName;

            Write(DateTime.Now.ToLongTimeString() + "\n");
        }

        public void Write(string data)
        {
            File.AppendAllText(_path, data);
        }
    }
}
