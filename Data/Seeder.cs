using SlimeAdventure.Data.Models;

namespace SlimeAdventure.Data;

public static class Seeder
{
    public static void Seed(GameDbContext db)
    {
        if (db.Rooms.Any()) return;

        var nest = new RoomEntity
        {
            Name = "Slime Nest",
            Description = "Your birthplace. Gooey walls and squishy floors surround you."
        };
        var cave = new RoomEntity
        {
            Name = "Cave Mouth",
            Description = "The entrance to the outside world. Light filters through moss."
        };
        var tunnel = new RoomEntity
        {
            Name = "Dark Tunnel",
            Description = "A musty tunnel filled with glowing mushrooms and echoes."
        };
        var fountain = new RoomEntity
        {
            Name = "Ancient Fountain",
            Description = "A glowing pool. As you near it, you feel your mass stabilizing."
        };

        db.Rooms.AddRange(nest, cave, tunnel, fountain);
        db.SaveChanges();

        nest.WestRoom = cave;
        cave.EastRoom = nest;

        nest.EastRoom = tunnel;
        tunnel.WestRoom = nest;

        tunnel.NorthRoom = fountain;
        fountain.SouthRoom = tunnel;

        // Set directional IDs
        nest.WestRoomId = cave.Id;
        nest.EastRoomId = tunnel.Id;
        tunnel.NorthRoomId = fountain.Id;

        db.SaveChanges();
    }
}
