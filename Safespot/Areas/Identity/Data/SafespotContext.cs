using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safespot.Service.DTO.UserDto;

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
    }
}
