using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.Core.Abstraction.Data
{
    public abstract class ItemBase//TODO: <TUniqueId>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
