using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class Employee : ItemBase//TODO Как?!
    {
        public long UserId { get;set; }//TODO: Связь?!
    }
}
