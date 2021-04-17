using Lesson5.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Lesson5
{
    public class ToDoReader : IReader<ToDo>
    {
        readonly string _path;
        public ToDoReader(string fileName)
        {
            _path = Directory.GetCurrentDirectory() + "\\" + fileName;
        }

        public List<ToDo> Read()
        {
            List<ToDo> list = new List<ToDo>();
            if (File.Exists(_path))
            {
                string data = File.ReadAllText(_path);

                list = JsonSerializer.Deserialize<List<ToDo>>(data);
            }

            
            return list;
        }
    }
}
