using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CustomThreadPool;

internal class CustomTask
{
    public Action Action { get; set; }
    public int Id { get; set; }
    public CustomTask(Action action, int id)
    {
        Action = action;
        Id = id;
    }
}
