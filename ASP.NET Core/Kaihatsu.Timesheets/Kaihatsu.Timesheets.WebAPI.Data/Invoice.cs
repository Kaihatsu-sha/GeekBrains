using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class Invoice : ItemBase
    {
        public DateTime DateStart { get; protected set; }
        public DateTime DateEnd { get; protected set; }
        public List<Sheet> Sheets { get; set; } = new List<Sheet>();


        public void Create()
        {
            DateStart = DateTime.Now;
        }

        public void IncludeSheets(IEnumerable<Sheet> sheets)
        {
            Sheets.AddRange(sheets);
        }
    }
}
