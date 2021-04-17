using Lesson5.Interfaces;
using System.Collections.Generic;

namespace Lesson5
{
    public class ToDo : IToDo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo()
        {
            Title = "";
            IsDone = false;
        }

        public ToDo(string Title, bool isDone)
        {
            Title = Title;
            IsDone = isDone;
        }
    }
}
