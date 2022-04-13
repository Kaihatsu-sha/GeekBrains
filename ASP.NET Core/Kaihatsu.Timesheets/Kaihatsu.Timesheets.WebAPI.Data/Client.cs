using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class Client : ItemBase
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IEnumerable<Contract> Contracts { get; set; }
        public virtual IEnumerable<Invoice> Invoices { get; set; }
    }
}
