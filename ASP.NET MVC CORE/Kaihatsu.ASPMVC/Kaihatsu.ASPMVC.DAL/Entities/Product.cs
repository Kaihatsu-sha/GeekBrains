using Kaihatsu.ASPMVC.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kaihatsu.ASPMVC.DAL.Entities;

public class Product : Entity
{
    public string Name { get; set; }
    [Column(TypeName="decimal(18,2)")]
    public decimal Price { get; set; }
    public string? Category { get; set; }
}
