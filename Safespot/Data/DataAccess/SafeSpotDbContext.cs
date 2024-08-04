﻿using Microsoft.EntityFrameworkCore;
using Safespot.Models.Entities;

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
        }
        #endregion
    }
}
