using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife2
{
    public class World
    {
        public static ISet<Coordinate> Tick(ISet<Coordinate> aliveCells)
        {
            var newAliveCells = new HashSet<Coordinate>();
            foreach (var aliveCell in aliveCells)
            {
                if (aliveCell.RemainsAlive(aliveCells))
                    newAliveCells.Add(aliveCell);

                aliveCell.GetNeighbours().Where(c =>
                    !aliveCells.Contains(c) &&
                    c.BecomesAlive(aliveCells)
                ).ToList().ForEach(c => newAliveCells.Add(c));
            }
            return newAliveCells;
        }
    }

    public class Cell
    {
        public static bool GetNewState(bool currentState, int numAliveNeighbours)
        {
            return numAliveNeighbours == 3 || (currentState && numAliveNeighbours == 2);
        }
    }
    
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

        public bool RemainsAlive(ISet<Coordinate> alive)
        {
            return Cell.GetNewState(alive.Contains(this), GetAliveNeighbours(alive));
        }

        public bool BecomesAlive(ISet<Coordinate> alive)
        {
            return RemainsAlive(alive);
        }
    }
}
