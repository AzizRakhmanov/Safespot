using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Safespot.Mvc.Areas.Identity.Data;

namespace Safespot.Mvc.Data;

public class SafeSpotDbContext : IdentityDbContext<LoginModel>
{
    public SafeSpotDbContext(DbContextOptions<SafeSpotDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<LoginModel>
{
    public void Configure(EntityTypeBuilder<LoginModel> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(100);
        builder.Property(x => x.LastName).HasMaxLength(100);
        builder.Property(x => x.MiddleName).HasMaxLength(100);
        builder.Property(x => x.BirthDate);
    }
}
