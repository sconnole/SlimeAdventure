namespace SlimeAdventure.Data.Models;

public class PlayerEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int CurrentRoomId { get; set; }
}