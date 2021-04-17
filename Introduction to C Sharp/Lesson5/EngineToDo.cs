using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lesson5.Interfaces;

namespace Lesson5
{
    public class EngineToDo
    {
        List<IToDo> _toDos;
        IWriter _writer;
        IReader<ToDo> _reader;

        public EngineToDo(string fileName)
        {
            _toDos = new List<IToDo>();
            _writer = new StringWriter(fileName);
            _reader = new ToDoReader(fileName);
        }

        public List<ToDo> ReadAll()
        {
            return _reader.Read();
        }

        public void WriteAll(List<ToDo> list)
        {
            string data = "";

            data = JsonSerializer.Serialize<List<ToDo>>(list);

            _writer.Write(data);
        }
    }
}
