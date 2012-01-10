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
    }
}
