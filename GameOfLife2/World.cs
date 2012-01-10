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
                if (Cell.GetNewState(true, aliveCell.GetAliveNeighbours(aliveCells)))
                    newAliveCells.Add(aliveCell);
                aliveCell.GetNeighbours().Where(c =>
                    !aliveCells.Contains(c) &&
                    Cell.GetNewState(false, c.GetAliveNeighbours(aliveCells))
                ).ToList().ForEach(c => newAliveCells.Add(c));
            }
            return newAliveCells;
        }
    }
}
