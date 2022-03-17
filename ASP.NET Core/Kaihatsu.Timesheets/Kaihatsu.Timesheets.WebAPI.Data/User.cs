using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System.ComponentModel.DataAnnotations;
using System;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class User : ItemBase
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(36, MinimumLength = 5)]
        public string PasswordHash { get; set; }//FIX: Хранение пароля
        public string Company { get; set; }
        [Range(18,121)]
        public int Age { get; set; }
    }
}
