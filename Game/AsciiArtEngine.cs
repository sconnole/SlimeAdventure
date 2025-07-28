using System;
using System.Collections.Generic;
using System.Threading;

namespace SlimeAdventure.Display
{
    public enum MovementDirection
    {
        Up,
        Down,
        Left,
        Right,
        BlockedUp,
        BlockedDown,
        BlockedLeft,
        BlockedRight
    }

    public static class AsciiArtEngine
    {
        private static readonly Dictionary<MovementDirection, string[]> SlimeAnimations = new()
        {
            [MovementDirection.Up] = new[]
            {
                "     ^     \n   (o_o)   \n   /|||\\   ",
                "     |     \n   (o_o)   \n   /|||\\   ",
                "           \n   (o_o)   \n   /|||\\   ",
            },
            [MovementDirection.Down] = new[]
            {
                "   /|||\\   \n   (o_o)   \n     |     ",
                "   /|||\\   \n   (o_o)   \n     v     ",
                "   /|||\\   \n   (o_o)   \n    \\_/    ",
            },
            [MovementDirection.Left] = new[]
            {
                "   (o_o)   \n  <|||     \n           ",
                "   (o_o)   \n <<|||     \n           ",
                "   (o_o)   \n<<<|||     \n           ",
            },
            [MovementDirection.Right] = new[]
            {
                "   (o_o)   \n     |||>  \n           ",
                "   (o_o)   \n     |||>> \n           ",
                "   (o_o)   \n     |||>>> \n          ",
            },
            [MovementDirection.BlockedUp] = new[]
            {
                "    [X]    \n   (x_x)   \n   /|||\\   ",
                "    [#]    \n   (x_x)   \n   /|||\\   ",
                "    [X]    \n   (x_x)   \n   /|||\\   ",
            },
            [MovementDirection.BlockedDown] = new[]
            {
                "   /|||\\   \n   (x_x)   \n    [X]    ",
                "   /|||\\   \n   (x_x)   \n    [#]    ",
                "   /|||\\   \n   (x_x)   \n    [X]    ",
            },
            [MovementDirection.BlockedLeft] = new[]
            {
                " [X](x_x)  \n   |||     \n           ",
                " [#](x_x)  \n   |||     \n           ",
                " [X](x_x)  \n   |||     \n           ",
            },
            [MovementDirection.BlockedRight] = new[]
            {
                "  (x_x)[X] \n     |||   \n           ",
                "  (x_x)[#] \n     |||   \n           ",
                "  (x_x)[X] \n     |||   \n           ",
            },
        };

        public static void ShowMovement(MovementDirection direction)
        {
            if (!SlimeAnimations.ContainsKey(direction)) return;

            foreach (var frame in SlimeAnimations[direction])
            {
                Console.Clear();
                Console.WriteLine(frame);
                Thread.Sleep(150);
            }
        }
    }
}
