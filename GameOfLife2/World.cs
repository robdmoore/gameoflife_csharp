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
}
