using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
}