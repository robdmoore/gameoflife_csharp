using GameOfLife.Implementation;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    class PointShould
    {
        [Test]
        public void Equals_the_same_point()
        {
            var p = new Point(1, 2);
            var p2 = new Point(1, 2);
            Assert.That(p, Is.EqualTo(p2));
        }

        [Test]
        public void Doesnt_equal_a_different_point()
        {
            var p = new Point(1, 2);
            var p2 = new Point(1, 1);
            Assert.That(p, Is.Not.EqualTo(p2));
        }

        [Test]
        public void Converts_to_a_string()
        {
            var p = new Point(1, 2);
            var p2 = new Point(1, 1);
            Assert.That(p.ToString(), Is.EqualTo("(1,2)"));
            Assert.That(p2.ToString(), Is.EqualTo("(1,1)"));
        }

        [Test]
        public void Construct_itself_properly()
        {
            var p = new Point(1, 2);
            Assert.That(p.X, Is.EqualTo(1));
            Assert.That(p.Y, Is.EqualTo(2));
        }

        [Test]
        public void Return_neighbours()
        {
            var p = new Point(1, 2);
            var n = p.GetNeighbourhood();
            Assert.That(n, Has.Length.EqualTo(8));
            Assert.That(n, Has.Member(new Point(0, 1)));
            Assert.That(n, Has.Member(new Point(1, 1)));
            Assert.That(n, Has.Member(new Point(2, 1)));
            Assert.That(n, Has.Member(new Point(0, 2)));
            Assert.That(n, Has.Member(new Point(2, 2)));
            Assert.That(n, Has.Member(new Point(0, 3)));
            Assert.That(n, Has.Member(new Point(1, 3)));
            Assert.That(n, Has.Member(new Point(2, 3)));
        }
    }
}
