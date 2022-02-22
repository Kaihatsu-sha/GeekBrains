using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System.ComponentModel.DataAnnotations;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class Employee : ItemBase
    {
        [Required]
        [Range(1,long.MaxValue)]
        public long UserId { get;set; }
        public virtual User User { get;set; }
    }
}
