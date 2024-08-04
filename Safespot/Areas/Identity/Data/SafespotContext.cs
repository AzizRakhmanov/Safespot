using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safespot.Areas.Identity.Models;

namespace Safespot.Data;

public class SafespotContext : IdentityDbContext<UserForLoginDto>
{
    public SafespotContext(DbContextOptions<SafespotContext> options)
        : base(options)
    {
    }

    public DbSet<UserForLoginDto> UserForLoginDtos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
