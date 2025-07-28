namespace SlimeAdventure.Data.Models;

public class RoomEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public int? NorthRoomId { get; set; }
    public int? SouthRoomId { get; set; }
    public int? EastRoomId { get; set; }
    public int? WestRoomId { get; set; }

    public RoomEntity? NorthRoom { get; set; }
    public RoomEntity? SouthRoom { get; set; }
    public RoomEntity? EastRoom { get; set; }
    public RoomEntity? WestRoom { get; set; }

}