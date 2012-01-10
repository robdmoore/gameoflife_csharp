using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class CellTests
    {
        [Test]
        public void Any_live_cell_with_fewer_than_2_neighbours_will_die([Values(0,1)] int numAliveNeighbours)
        {
            Assert.That(GetNewState(numAliveNeighbours), Is.False);
        }

        [Test]
        public void Any_live_cell_with_more_than_3_neighbours_will_die([Values(4, 5, 6, 7, 8)] int numAliveNeighbours)
        {
            Assert.That(GetNewState(numAliveNeighbours), Is.False);
        }

        private static bool GetNewState(int numAliveNeighbours)
        {
            var alive = true;
            if (numAliveNeighbours < 2 || numAliveNeighbours > 3)
                alive = false;
            return alive;
        }
    }
}
