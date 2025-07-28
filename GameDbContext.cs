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
}