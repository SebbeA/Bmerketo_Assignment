using Bmerketo.Models.Entities;
using Bmerketo.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmerketo.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var roleId = Guid.NewGuid().ToString();
        var userId = Guid.NewGuid().ToString();

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { 
                Id = roleId,
                Name = "admin",
                NormalizedName = "ADMIN"
            }    
        );

        var passwordHasher = new PasswordHasher<AppUser>();

        builder.Entity<AppUser>().HasData(new AppUser
        {
            Id = userId,
            FirstName = "System",
            LastName = "Admin",
            UserName = "administrator@domian.com",
            Email = "administrator@domian.com",
            PasswordHash = passwordHasher.HashPassword(null!, "BytMig123!")
        });

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = roleId,
            UserId = userId
        });
        
    }
}
