using SlimeAdventure.Data;

public class GameEngine
{
    private readonly GameDbContext _db;

    public GameEngine(GameDbContext db)
    {
        _db = db;
    }

    public void Start()
    {
        Console.WriteLine("Welcome!");
    }
}