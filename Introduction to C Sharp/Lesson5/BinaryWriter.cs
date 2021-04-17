using Lesson5.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson5
{
    class BinaryWriter : IWriter
    {
        readonly string _path;
        public BinaryWriter(string fileName)
        {
            _path = Directory.GetCurrentDirectory() + "\\" + fileName;
        }
        public void Write(string data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(new FileStream(_path, FileMode.OpenOrCreate), data);
        }

    }
}
