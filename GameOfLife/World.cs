using System;
using System.Linq;
using System.Threading;
using GameOfLife.Implementation;

namespace GameOfLife
{
    public class World
    {
        private readonly Grid _grid;

        public World(params int[] initialCoords)
        {
            _grid = new Grid();
            for (var i = 0; i < initialCoords.Length; i += 2)
            {
                _grid.AddPoint(initialCoords[i], initialCoords[i + 1]);
            }
        }

        // ReSharper disable FunctionNeverReturns
        public void Run()
        {
            while (true)
            {
                Display();
                Thread.Sleep(100);
                Implementation.GameOfLife.Tick(_grid).ToList().ForEach(a => a());
            }
        }
        // ReSharper restore FunctionNeverReturns

        public void Display()
        {
            Console.Clear();
            var d = _grid.GetDimensions();
            for (var y = d.MinY; y <= d.MaxY; y++)
            {
                for (var x = d.MinX; x <= d.MaxX; x++)
                {
                    // ReSharper disable PossibleInvalidOperationException
                    Console.Write(_grid.Has(x.Value, y.Value) ? "X" : "-");
                    // ReSharper restore PossibleInvalidOperationException
                }
                Console.WriteLine();
            }
        }

        
    }
}
