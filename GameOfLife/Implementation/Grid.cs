using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Implementation
{
    public class Grid
    {
        private readonly Dictionary<string, Point> _points;

        public Grid()
        {
            _points = new Dictionary<string, Point>();
        }

        public void AddPoint(int x, int y)
        {
            if (Has(x, y))
                return;
            var p = new Point(x, y);
            _points[p.ToString()] = p;
        }

        public Dimensions GetDimensions()
        {
            var d = new Dimensions();
            foreach (var p in _points.Values)
            {
                d.X = p.X;
                d.Y = p.Y;
            }
            return d;
        }

        public bool Has(int x, int y)
        {
            var p = new Point(x, y);
            return _points.ContainsKey(p.ToString());
        }

        public IEnumerable<Point> GetAll()
        {
            return _points.Values;
        }

        public void RemovePoint(int x, int y)
        {
            var p = new Point(x, y);
            _points.Remove(p.ToString());
        }

        public Grid Expand()
        {
            var g = new Grid();
            GetAll().ToList().ForEach(p => g.AddPoint(p.X, p.Y));
            GetAll().SelectMany(p => p.GetNeighbourhood()).ToList().ForEach(p => g.AddPoint(p.X, p.Y));
            return g;
        }
    }

    public class Dimensions
    {
        private int? _minX;
        public int MinX
        {
            get { return _minX == null ? 0 : _minX.Value; }
        }

        private int? _maxX;
        public int MaxX
        {
            get { return _maxX == null ? 0 : _maxX.Value; }
        }

        private int? _minY;
        public int MinY
        {
            get { return _minY == null ? 0 : _minY.Value; }
        }

        private int? _maxY;
        public int MaxY
        {
            get { return _maxY == null ? 0 : _maxY.Value; }
        }

        public int X
        {
            set
            {
                if (_minX == null || value < _minX)
                    _minX = value;
                if (_maxX == null || value > _maxX)
                    _maxX = value;
            }
        }

        public int Y
        {
            set
            {
                if (_minY == null || value < _minY)
                    _minY = value;
                if (_maxY == null || value > _maxY)
                    _maxY = value;
            }
        }
    }

    public class Point
    {
        #region Setup
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0},{1})", X, Y);
        }

        public override bool Equals(object o)
        {
            if (o.GetType() != typeof(Point))
                return base.Equals(o);
            var p = (Point)o;
            return p.X == X && p.Y == Y;
        }
        #endregion

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Point> GetNeighbourhood()
        {
            return new[]
            {
                new Point(X-1, Y-1),
                new Point(X  , Y-1),
                new Point(X+1, Y-1),
                new Point(X+1, Y  ),
                new Point(X+1, Y+1),
                new Point(X  , Y+1),
                new Point(X-1, Y+1),
                new Point(X-1, Y  )
            };
        }
    }
}
