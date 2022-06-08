using Kaihatsu.ASPMVC.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Kaihatsu.ASPMVC.DAL.Entities;

public class OrderItem: Entity
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    [Required]
    public Order Order { get; set; }
}
