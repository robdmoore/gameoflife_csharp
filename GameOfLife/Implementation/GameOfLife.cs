using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Implementation
{
    public class GameOfLife
    {
        public static IEnumerable<Action> Tick(Grid grid)
        {
            var actions = new List<Action>();
            var points = grid.Expand().GetAll();
            foreach (var pp in points)
            {
                var p = pp;
                var isAlive = grid.Has(p.X, p.Y);
                var neighboursAlive = p.GetNeighbourhood().Aggregate(0, (count, np) => count + (grid.Has(np.X, np.Y) ? 1 : 0));
                if (neighboursAlive == 3 && !isAlive)
                    actions.Add(() => grid.AddPoint(p.X, p.Y));
                else if ((neighboursAlive < 2 || neighboursAlive > 3) && isAlive)
                    actions.Add(() => grid.RemovePoint(p.X, p.Y));
            }

            return actions;
        }
    }
}
