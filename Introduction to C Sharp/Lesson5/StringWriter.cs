using Lesson5.Interfaces;
using System.IO;

namespace Lesson5
{
    class StringWriter : IWriter
    {
        readonly string _path;

        public StringWriter(string fileName)
        {
            _path = Directory.GetCurrentDirectory() + "\\" + fileName;
        }

        public void Write(string data)
        {
            File.WriteAllText(_path, data);
        }

    }
}
