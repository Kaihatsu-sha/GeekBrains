using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee : ItemBase
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long UserId { get;set; }
        public virtual User User { get;set; }

        public virtual IEnumerable<Contract> Contracts { get;set; }
        public virtual IEnumerable<Sheet> Sheets { get;set; }
    }
}
