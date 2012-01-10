using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class WorldShould
    {
        [Test, Combinatorial]
        public void Return_number_of_alive_neighbours_for_a_coordinate_and_a_list_of_alive_cells([Range(-1,1)] int x, [Range(-1,1)] int y)
        {
            var cell = new Coordinate(x, y);
            var aliveCells = new HashSet<Coordinate> {new Coordinate(-1, -1), new Coordinate(1, 1)};

            var numNeighbours = 0;

            var expectedNeighbours = 1;
            if (x == 0 && x == 0)
                expectedNeighbours = 1;
            if ((x > 0 && y > 0) || (x < 0 && y < 0))
                expectedNeighbours = 0;

            Assert.That(numNeighbours, Is.EqualTo(expectedNeighbours));
        }
    }
}
