using Kaihatsu.ASPMVC.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace Kaihatsu.ASPMVC.DAL.Entities;

public class Order : Entity
{
    public DateTime Date { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public string Phone { get; set; }
    [Required]
    public Buyer Buyer { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
}
