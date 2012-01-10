using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class WorldShould
    {
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
        public void Return_number_of_alive_neighbours_for_a_coordinate_and_a_list_of_alive_cells([Range(-2,2)] int x, [Range(-2,2)] int y)
        {
            var cell = new Coordinate(x, y);
            var aliveCells = new HashSet<Coordinate> {new Coordinate(-1, -1), new Coordinate(1, 1)};

            var numNeighbours = cell.GetNeighbours().Count(aliveCells.Contains);

            var expectedNeighbours = 1;
            if (x == 0 && y == 0)
                expectedNeighbours = 2;
            if ((x > 0 && y < 0) || (x < 0 && y > 0) || aliveCells.Contains(cell))
                expectedNeighbours = 0;

            Assert.That(numNeighbours, Is.EqualTo(expectedNeighbours));
        }
    }
}
