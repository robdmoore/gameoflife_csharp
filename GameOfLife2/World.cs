﻿using System;
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

        public static ISet<Coordinate> IntsToCoords(IList<int> ints)
        {
            var coords = new HashSet<Coordinate>();
            for (var i = 0; i < ints.Count; i += 2)
            {
                coords.Add(new Coordinate(ints[i], ints[i + 1]));
            }
            return coords;
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

        public int X { get { return Item1; } }
        public int Y { get { return Item2; } }

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
