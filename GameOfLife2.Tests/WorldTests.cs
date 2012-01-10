﻿using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife2.Tests
{
    [TestFixture]
    class WorldShould
    {
        [Test]
        public void Convert_set_of_alive_cells_to_new_set_of_alive_cells()
        {
            var aliveCells = new HashSet<Coordinate> {new Coordinate(0,1), new Coordinate(1,1), new Coordinate(2,1)};
            var newAliveCells = World.Tick(aliveCells);

            Assert.That(newAliveCells, Has.Count.EqualTo(3));
            Assert.That(newAliveCells, Has.Member(new Coordinate(1, 0)));
            Assert.That(newAliveCells, Has.Member(new Coordinate(1, 1)));
            Assert.That(newAliveCells, Has.Member(new Coordinate(1, 2)));
        }
    }
}
