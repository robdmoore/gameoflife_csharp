using System;
using System.Linq;
using System.Threading;

namespace GameOfLife2
{
    class Program
    {
        static void Main()
        {
            var coords = World.IntsToCoords(new[] {
                 1,5,  1,6,  2,5,  2,6, 11,5, 11,6, 11,7, 12,4, 12,8,
                14,3, 13,9, 14,9, 15,6, 16,4, 16,8, 17,5, 17,6, 17,7,
                18,6, 21,3, 21,4, 21,5, 22,3, 22,4, 22,5, 23,2, 23,6,
                25,1, 25,2, 25,6, 25,7, 35,3, 35,4, 36,3, 36,4, 13,3
            });

            while (true)
            {
                var minX = coords.Min(c => c.X);
                var maxX = coords.Max(c => c.X);
                var minY = coords.Min(c => c.Y);
                var maxY = coords.Max(c => c.Y);
                Console.Clear();
                for (var y = minY; y <= maxY; y++)
                {
                    for (var x = minX; x <= maxX; x++)
                    {
                        Console.Write(coords.Contains(new Coordinate(x,y)) ? 'X' : ' ');
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(500);
                coords = World.Tick(coords);
            }
        }
    }
}
