using Microsoft.EntityFrameworkCore;
using Safespot.Models.Entities;
using Safespot.Service.DTO.ParkingZoneDto;
using Safespot.Service.DTO.ParkingZone;

namespace Safespot.Data.DataAccess
{
    public class SafeSpotDbContext : DbContext
    {
        public SafeSpotDbContext(DbContextOptions<SafeSpotDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<ParkingZone> ParkingZones { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Slot> Slots { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<CarPlateNumber> CarPlateNumbers { get; set; }

        #region

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Reservation>()
            //    .HasOne(p => p.ParkingZone)
            //    .WithMany()
            //    .HasForeignKey(p => p.ParkingZone)
            //    .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Reservation>()
                .HasOne(p => p.Slot)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Slot>()
                .HasOne(p => p.ParkingZone)
                .WithMany()
                .HasForeignKey(p => p.ParkingZoneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserSlot>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserSlot>()
                .HasOne(p => p.Slot)
                .WithMany()
                .HasForeignKey(p => p.SlotId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserSlot>()
                .HasOne(p => p.ParkingZone)
                .WithMany()
                .HasForeignKey(p => p.ParkingZoneId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Slot>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            builder.Entity<Reservation>()
                .Property(p => p.PaidAmount)
                .HasPrecision(18, 2);
        }
        public DbSet<Safespot.Service.DTO.ParkingZoneDto.ParkingZoneForCreationDto> ParkingZoneForCreationDto { get; set; }
        public DbSet<Safespot.Service.DTO.ParkingZoneDto.ParkingZoneForResultDto> ParkingZoneForResultDto { get; set; }
        public DbSet<Safespot.Service.DTO.ParkingZone.ParkingZoneForDetailsDto> ParkingZoneForDetailsDto { get; set; }
        #endregion
    }
}
