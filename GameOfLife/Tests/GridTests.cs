using GameOfLife.Implementation;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    class GridShould
    {
        [Test]
        public void Have_no_initial_dimensions()
        {
            var d = new Grid().GetDimensions();

            Assert.That(d.MinX, Is.Null);
            Assert.That(d.MaxX, Is.Null);
            Assert.That(d.MinY, Is.Null);
            Assert.That(d.MaxY, Is.Null);
        }

        [Test]
        public void Return_correct_dimensions()
        {
            var g = new Grid();
            g.AddPoint(-1, -5);
            g.AddPoint(5, 10);
            var d = g.GetDimensions();

            Assert.That(d.MinX, Is.EqualTo(-1));
            Assert.That(d.MinY, Is.EqualTo(-5));
            Assert.That(d.MaxX, Is.EqualTo(5));
            Assert.That(d.MaxY, Is.EqualTo(10));
        }

        [Test]
        public void Set_coordinate()
        {
            var g = new Grid();
            Assert.That(g.Has(1,1), Is.False);
            g.AddPoint(1, 1);
            Assert.That(g.Has(1,1));
        }

        [Test]
        public void Remove_coordinate()
        {
            var g = new Grid();
            g.AddPoint(1, 1);
            Assert.That(g.Has(1, 1));
            g.RemovePoint(1, 1);
            Assert.That(g.Has(1, 1), Is.False);
        }

        [Test]
        public void Starts_off_empty()
        {
            Assert.That(new Grid().GetAll(), Is.Empty);
        }

        [Test]
        public void Returns_all_points()
        {
            var g = new Grid();
            g.AddPoint(1, 2);
            var p = g.GetAll();
            Assert.That(p, Has.Count.EqualTo(1));
            Assert.That(p, Has.Member(new Point(1,2)));
        }

        [Test]
        public void Expands_to_nothing_when_empty()
        {
            Assert.That(new Grid().Expand().GetAll(), Is.Empty);
        }

        [Test]
        public void Expands_a_single_point_grid_correctly()
        {
            var g = new Grid();
            g.AddPoint(1, 2);
            var p = g.Expand().GetAll();
            Assert.That(p, Has.Count.EqualTo(9));
            Assert.That(p, Has.Member(new Point(1, 2)));
            Assert.That(p, Has.Member(new Point(0, 1)));
            Assert.That(p, Has.Member(new Point(1, 1)));
            Assert.That(p, Has.Member(new Point(2, 1)));
            Assert.That(p, Has.Member(new Point(0, 2)));
            Assert.That(p, Has.Member(new Point(2, 2)));
            Assert.That(p, Has.Member(new Point(0, 3)));
            Assert.That(p, Has.Member(new Point(1, 3)));
            Assert.That(p, Has.Member(new Point(2, 3)));
        }

        [Test]
        public void Expands_two_point_grid_correctly()
        {
            var g = new Grid();
            g.AddPoint(1, 2);
            g.AddPoint(1, 3);
            var p = g.Expand().GetAll();
            Assert.That(p, Has.Count.EqualTo(12));
            Assert.That(p, Has.Member(new Point(1, 2)));
            Assert.That(p, Has.Member(new Point(0, 1)));
            Assert.That(p, Has.Member(new Point(1, 1)));
            Assert.That(p, Has.Member(new Point(2, 1)));
            Assert.That(p, Has.Member(new Point(0, 2)));
            Assert.That(p, Has.Member(new Point(2, 2)));
            Assert.That(p, Has.Member(new Point(0, 3)));
            Assert.That(p, Has.Member(new Point(1, 3)));
            Assert.That(p, Has.Member(new Point(2, 3)));
            Assert.That(p, Has.Member(new Point(0, 4)));
            Assert.That(p, Has.Member(new Point(1, 4)));
            Assert.That(p, Has.Member(new Point(2, 4)));
        }
    }
}
