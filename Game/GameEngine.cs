using System.Runtime.CompilerServices;
using SlimeAdventure.Data;
using SlimeAdventure.Data.Models;
using SlimeAdventure.Display;

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
                if (room!.NorthRoomId.HasValue)
                {
                    AsciiArtEngine.ShowMovement(MovementDirection.Up);
                    MoveTo(room.NorthRoomId.Value);
                }
                else AsciiArtEngine.ShowMovement(MovementDirection.BlockedUp);
                break;
            case ConsoleKey.DownArrow:
                if (room!.SouthRoomId.HasValue)
                {
                    AsciiArtEngine.ShowMovement(MovementDirection.Down);
                    MoveTo(room.SouthRoomId.Value);
                }
                else AsciiArtEngine.ShowMovement(MovementDirection.BlockedDown);
                break;
            case ConsoleKey.LeftArrow:
                if (room!.WestRoomId.HasValue)
                {
                    AsciiArtEngine.ShowMovement(MovementDirection.Left);
                    MoveTo(room.WestRoomId.Value);
                }
                else AsciiArtEngine.ShowMovement(MovementDirection.BlockedLeft);
                break;
            case ConsoleKey.RightArrow:
                if (room!.EastRoomId.HasValue)
                {
                    AsciiArtEngine.ShowMovement(MovementDirection.Right);
                    MoveTo(room.EastRoomId.Value);
                }
                else AsciiArtEngine.ShowMovement(MovementDirection.BlockedRight);
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