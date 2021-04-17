using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Interfaces
{
    interface IEmployee
    {
        string Phone { get; set; }
        string EMail { get; }
        string Position { get; set; }
        float Salary { get; set; }

        IPerson Person { get; }

        void OutputToConsole();
    }
}
