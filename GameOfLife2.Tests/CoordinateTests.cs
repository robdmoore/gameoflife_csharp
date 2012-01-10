using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class CoordinateShould
    {
        [Test, Combinatorial]
        public void Have_equality([Range(-10,10)] int x, [Range(-10,10)] int y)
        {
            var c1 = new Coordinate(x, y);
            var c2 = new Coordinate(x, y);
            Assert.That(c1, Is.EqualTo(c2));
        }

        [Test]
        public void Have_inequality()
        {
            var c1 = new Coordinate(-1, 2);
            var c2 = new Coordinate(2, -1);
            Assert.That(c1, Is.Not.EqualTo(c2));
        }

        [Test, Combinatorial]
        public void Return_its_neighbours([Range(-10,10)] int x, [Range(-10,10)] int y)
        {
            var c = new Coordinate(x, y);
            var neighbours = c.GetNeighbours();
            Assert.That(neighbours, Has.Length.EqualTo(8), c.ToString());
            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    Assert.That(neighbours, Has.Member(new Coordinate(x+i, y+j)), c.ToString());
                }
            }
        }


        [Test, Combinatorial]
        /*
                        Y
            0 0 0 0 0  -2
            0 1 0 0 0  -1
            0 0 0 0 0   0
            0 0 0 1 0   1
            0 0 0 0 0   2

         X -2-1 0 1 2
        */
        public void Return_number_of_alive_neighbours_for_a_coordinate_and_a_list_of_alive_cells([Range(-2, 2)] int x, [Range(-2, 2)] int y)
        {
            var cell = new Coordinate(x, y);
            var aliveCells = new HashSet<Coordinate> { new Coordinate(-1, -1), new Coordinate(1, 1) };

            var numNeighbours = cell.GetAliveNeighbours(aliveCells);

            var expectedNeighbours = 1;
            if (x == 0 && y == 0)
                expectedNeighbours = 2;
            if ((x > 0 && y < 0) || (x < 0 && y > 0) || aliveCells.Contains(cell))
                expectedNeighbours = 0;

            Assert.That(numNeighbours, Is.EqualTo(expectedNeighbours));
        }

        [Test]
        public void Return_next_state_given_list_of_alive_cells_for_live_cell_staying_alive()
        {
            var cell = new Coordinate(0, 0);
            var alive = new HashSet<Coordinate> { new Coordinate(0,0), new Coordinate(1,1), new Coordinate(-1,-1) };
            Assert.That(cell.RemainsAlive(alive));
        }

        [Test]
        public void Return_next_state_given_list_of_alive_cells_for_live_cell_dieing()
        {
            var cell = new Coordinate(0, 0);
            var alive = new HashSet<Coordinate> { new Coordinate(0, 0), new Coordinate(1, 1) };
            Assert.That(cell.RemainsAlive(alive), Is.False);
        }

        [Test]
        public void Return_next_state_given_list_of_alive_cells_for_dead_cell_becoming_alive()
        {
            var cell = new Coordinate(0, 0);
            var alive = new HashSet<Coordinate> { new Coordinate(-1, -1), new Coordinate(1, 1), new Coordinate(1, 0) };
            Assert.That(cell.BecomesAlive(alive));
        }

        [Test]
        public void Return_next_state_given_list_of_alive_cells_for_dead_cell_dieing()
        {
            var cell = new Coordinate(0, 0);
            var alive = new HashSet<Coordinate> { new Coordinate(1, 1) };
            Assert.That(cell.BecomesAlive(alive), Is.False);
        }
    }
}
