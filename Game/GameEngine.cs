using System.Runtime.CompilerServices;
using SlimeAdventure.Data;
using SlimeAdventure.Data.Models;

public class GameEngine
{
    private readonly GameDbContext _db;

    private PlayerEntity? _player;

    public GameEngine(GameDbContext db)
    {
        _db = db;
    }

    public void Start()
    {
        Console.WriteLine("Good morning sleepy head! And what is your name??");
        var name = Console.ReadLine()?.Trim() ?? "Pink Slime";

        _player = _db.Players.FirstOrDefault(p => p.Name == name);
        if (_player == null)
        {
            var room = _db.Rooms.First();
            _player = new PlayerEntity { Name = name, CurrentRoomId = room.Id };
            _db.Players.Add(_player);
            _db.SaveChanges();

            Console.WriteLine($"Wecome, {name}! Your journey starts now <3");
        }
        else
        {
            _player = new PlayerEntity { Name = name, CurrentRoomId = _player.CurrentRoomId};
            Console.WriteLine($"Welcome back, {name}");
        }

        GameLoop();
    }

    private void GameLoop()
    {
        while (true)
        {
            var room = _db.Rooms.Find(_player!.CurrentRoomId);
            Console.Clear();
            Console.WriteLine($"== {room!.Name} ==");
            Console.WriteLine(room.Description);
            Console.WriteLine("\nUse arrow keys to move. Press 'H' for help. Press 'Q' to quit.");

            var key = Console.ReadKey(intercept: true).Key;
            if (key == ConsoleKey.Q) break;

            HandleKey(key);
        }

        Console.WriteLine("You ooze into a puddle and rest... (Goodbye!)");
    }

    private void MoveTo(int roomId)
    {
        _player!.CurrentRoomId = roomId;
        _db.SaveChanges();
    }

    private void HandleKey(ConsoleKey key)
    {
        var room = _db.Rooms.Find(_player!.CurrentRoomId);

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (room!.NorthRoomId.HasValue) MoveTo(room.NorthRoomId.Value);
                else ShowBlocked();
                break;
            case ConsoleKey.DownArrow:
                if (room!.SouthRoomId.HasValue) MoveTo(room.SouthRoomId.Value);
                else ShowBlocked();
                break;
            case ConsoleKey.LeftArrow:
                if (room!.WestRoomId.HasValue) MoveTo(room.WestRoomId.Value);
                else ShowBlocked();
                break;
            case ConsoleKey.RightArrow:
                if (room!.EastRoomId.HasValue) MoveTo(room.EastRoomId.Value);
                else ShowBlocked();
                break;
            case ConsoleKey.H:
                ShowHelp();
                break;
            default:
                Console.WriteLine("Unknown input. Press 'H' for help.");
                Thread.Sleep(1000);
                break;
        }
    }


    private void ShowBlocked()
    {
        Console.WriteLine("You squish in place. That way is blocked.");
        Thread.Sleep(1000);
    }

    private void ShowHelp()
    {
        Console.Clear();
        Console.WriteLine("== HELP ==");
        Console.WriteLine("Arrow Keys - Move around");
        Console.WriteLine("H - Show this help menu");
        Console.WriteLine("Q - Quit the game");
        Console.WriteLine("\nPress any key to return to the game.");
        Console.ReadKey(intercept: true);
    }
}