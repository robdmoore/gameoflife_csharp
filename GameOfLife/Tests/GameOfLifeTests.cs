using System;
using System.Collections.Generic;
using System.Linq;
using GameOfLife.Implementation;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    static internal class ShuffleExtension
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> l)
        {
            var r = new Random();
            return l.OrderBy(i => r.Next());
        }
    }

    [TestFixture]
    class GameOfLifeShould
    {

        private static void PerformTest(int x, int y, int numLiveNeighbours, bool startsAlive, bool shouldLive)
        {
            var g = new Grid();
            var p = new Point(x, y);
            if (startsAlive)
                g.AddPoint(x, y);
            p.GetNeighbourhood().Shuffle().Take(numLiveNeighbours).ToList().ForEach(np => g.AddPoint(np.X, np.Y));
            Implementation.GameOfLife.Tick(g).ToList().ForEach(a => a());

            Assert.That(g.Has(x, y), Is.EqualTo(shouldLive));
        }

        [Test]
        public void Does_nothing_to_empty_grid()
        {
            Assert.That(Implementation.GameOfLife.Tick(new Grid()), Is.Empty);
        }

        [Test, Combinatorial]
        public void Kill_any_live_cell_with_fewer_than_two_or_more_than_three_live_neighbours([Range(-10, 10)] int x, [Range(-10, 10)] int y, [Values(0, 1, 4, 5, 6, 7, 8)] int numLiveNeighbours)
        {
            PerformTest(x, y, numLiveNeighbours, startsAlive: true, shouldLive: false);
        }

        [Test, Combinatorial]
        public void Keep_any_live_cell_with_two_or_three_live_neighbours([Range(-10, 10)] int x, [Range(-10, 10)] int y, [Values(2, 3)] int numLiveNeighbours)
        {
            PerformTest(x, y, numLiveNeighbours, startsAlive: true, shouldLive: true);
        }

        [Test, Combinatorial]
        public void Do_nothing_to_any_dead_cell_without_three_live_neighbours([Range(-10, 10)] int x, [Range(-10, 10)] int y, [Values(0, 1, 2, 4, 5, 6, 7, 8)] int numLiveNeighbours)
        {
            PerformTest(x, y, numLiveNeighbours, startsAlive: false, shouldLive: false);
        }

        [Test, Combinatorial]
        public void Revive_any_dead_cell_with_three_live_neighbours([Range(-10, 10)] int x, [Range(-10, 10)] int y)
        {
            PerformTest(x, y, numLiveNeighbours: 3, startsAlive: false, shouldLive: true);
        }
    }
}
