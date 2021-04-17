using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Interfaces
{
    interface IPerson
    {
        int Age { get; set; }
        string FirstName { get; }
        string LastName { get; }
        string Patronymic { get; }

        string FullName();
        string ShortName();
    }
}
