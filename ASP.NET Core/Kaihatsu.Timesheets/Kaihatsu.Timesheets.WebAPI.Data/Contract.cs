using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    /// <summary>
    /// Договор
    /// </summary>
    public class Contract : ItemBase
    {
        [Required(AllowEmptyStrings =false)]
        public string Title { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Description { get; set; }
        public float CostHourWork { get; set; }

        public ICollection<Sheet> Sheets { get; set; }
    }
}
