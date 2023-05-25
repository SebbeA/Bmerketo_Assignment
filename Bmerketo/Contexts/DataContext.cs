using Bmerketo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<ContactFormEntity> ContactMessage { get; set; }
    public DbSet<ProductEntity> Product { get; set; }
    public DbSet<ProductTagEntity> ProductTag { get; set; }
    public DbSet<TagEntity> Tag { get; set; }
}
