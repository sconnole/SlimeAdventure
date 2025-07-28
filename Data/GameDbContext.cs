using Microsoft.EntityFrameworkCore;
using SlimeAdventure.Data.Models;

namespace SlimeAdventure.Data;

public class GameDbContext : DbContext
{
    public DbSet<PlayerEntity> Players => Set<PlayerEntity>();
    public DbSet<RoomEntity> Rooms => Set<RoomEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=adventure.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoomEntity>()
            .HasOne(r => r.NorthRoom)
            .WithMany()
            .HasForeignKey(r => r.NorthRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoomEntity>()
            .HasOne(r => r.SouthRoom)
            .WithMany()
            .HasForeignKey(r => r.SouthRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoomEntity>()
            .HasOne(r => r.EastRoom)
            .WithMany()
            .HasForeignKey(r => r.EastRoomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoomEntity>()
            .HasOne(r => r.WestRoom)
            .WithMany()
            .HasForeignKey(r => r.WestRoomId)
            .OnDelete(DeleteBehavior.Restrict);
    }

}