using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class CellTests
    {
        [Test]
        public void Any_live_cell_with_fewer_than_2_live_neighbours_will_die([Values(0,1)] int numAliveNeighbours)
        {
            Assert.That(Cell.GetNewState(true, numAliveNeighbours), Is.False);
        }

        [Test]
        public void Any_live_cell_with_more_than_3_live_neighbours_will_die([Values(4, 5, 6, 7, 8)] int numAliveNeighbours)
        {
            Assert.That(Cell.GetNewState(true, numAliveNeighbours), Is.False);
        }

        [Test]
        public void Any_live_cell_with_2_or_3_live_neighbours_will_stay_alive([Values(2,3)] int numAliveNeighbours)
        {
            Assert.That(Cell.GetNewState(true, numAliveNeighbours), Is.True);
        }

        [Test]
        public void Any_dead_cell_with_3_live_neighbours_will_become_alive()
        {
            Assert.That(Cell.GetNewState(false, 3), Is.True);
        }

        [Test]
        public void Any_dead_cell_with_out_3_live_neighbours_stays_dead([Values(0, 1, 2, 4, 5, 6, 7, 8)] int numAliveNeighbours)
        {
            Assert.That(Cell.GetNewState(false, numAliveNeighbours), Is.False);
        }
    }
}
