using Kaihatsu.ASPMVC.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Kaihatsu.ASPMVC.DAL.Entities;

public class Buyer : Entity
{
    [Required]
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public int Age { get; set; }
}
