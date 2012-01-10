using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class WorldShould
    {
        [Test]
        public void Convert_set_of_alive_cells_to_new_set_of_alive_cells()
        {
            var aliveCells = new HashSet<Coordinate> {new Coordinate(0,2), new Coordinate(1,2), new Coordinate(2,2)};

            var newAliveCells = new HashSet<Coordinate>();

            Assert.That(newAliveCells, Has.Count.EqualTo(3));
            Assert.That(newAliveCells, Has.Member(new Coordinate(2, 0)));
            Assert.That(newAliveCells, Has.Member(new Coordinate(2, 1)));
            Assert.That(newAliveCells, Has.Member(new Coordinate(2, 2)));
        }
    }
}
