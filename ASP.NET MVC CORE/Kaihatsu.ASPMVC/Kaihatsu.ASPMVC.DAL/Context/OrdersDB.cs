
using Kaihatsu.ASPMVC.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kaihatsu.ASPMVC.DAL.Context;

public class OrdersDB : DbContext
{
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }


    public OrdersDB(DbContextOptions<OrdersDB> options):base(options)
    {

    }
}
