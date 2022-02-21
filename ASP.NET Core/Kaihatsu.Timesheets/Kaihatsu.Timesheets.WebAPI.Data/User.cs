using Kaihatsu.Timesheets.Core.Abstraction.Data;
using System;

namespace Kaihatsu.Timesheets.WebAPI.Data
{
    public class User : ItemBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }//FIX: Хранение пароля
        public string Company { get; set; }
        public int Age { get; set; }
    }
}
