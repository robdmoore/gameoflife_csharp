using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife2
{
    public class Coordinate : Tuple<int, int>
    {
        public Coordinate(int x, int y) : base(x, y) { }

        private int X { get { return Item1; } }
        private int Y { get { return Item2; } }

        public IEnumerable<Coordinate> GetNeighbours()
        {
            return new[]
            {
                new Coordinate(X-1, Y-1),
                new Coordinate(X  , Y-1),
                new Coordinate(X+1, Y-1),
                new Coordinate(X+1, Y  ),
                new Coordinate(X+1, Y+1),
                new Coordinate(X  , Y+1),
                new Coordinate(X-1, Y+1),
                new Coordinate(X-1, Y  ),
            };
        }

        public int GetAliveNeighbours(ICollection<Coordinate> aliveCells)
        {
            return GetNeighbours().Count(aliveCells.Contains);
        }
    }
}
