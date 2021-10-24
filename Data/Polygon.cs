using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Polygon : BaseShape
    {
        private readonly List<Vertice> _vertices;
        public Polygon()
        {
            _vertices = new List<Vertice>();
        }

        public override void UpdateShape(Vertice vertice) =>_vertices.Add(vertice);

        public void Remove(Vertice vertice) => _vertices.Remove(vertice);

        public void AddVertice(Vertice firstVertice, Vertice secondVertice)
        {
            var point = new Point((firstVertice.GetPosition().X + secondVertice.GetPosition().X) / 2,
                (firstVertice.GetPosition().Y + secondVertice.GetPosition().Y) / 2);
            var newVertice = new Vertice(point);
            int indexOfFirst = _vertices.IndexOf(firstVertice);
            int indexOfSecond = _vertices.IndexOf(secondVertice);
            if (indexOfFirst > indexOfSecond)
            {
                if (indexOfSecond == 0 && indexOfFirst == _vertices.Count - 1)
                {
                    _vertices.Add(newVertice);
                }
                else
                {
                    _vertices.Insert(indexOfFirst, newVertice);
                }
            }
            else
            {
                if (indexOfFirst == 0 && indexOfSecond == _vertices.Count - 1)
                {
                    _vertices.Add(newVertice);
                }
                else
                {
                    _vertices.Insert(indexOfSecond, newVertice);
                }
            }
        }

        public override bool CheckIfClicked(Point point)
        {
            bool result = false;
            int j = _vertices.Count() - 1;
            for (int i = 0; i < _vertices.Count(); i++)
            {
                if (_vertices[i].GetPosition().Y < point.Y && _vertices[j].GetPosition().Y >= point.Y 
                    || _vertices[j].GetPosition().Y < point.Y && _vertices[i].GetPosition().Y >= point.Y)
                {
                    if (_vertices[i].GetPosition().X + (point.Y - 
                        (double)_vertices[i].GetPosition().Y) / ((double)_vertices[j].GetPosition().Y - 
                        _vertices[i].GetPosition().Y) * (_vertices[j].GetPosition().X - _vertices[i].GetPosition().X) 
                        < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
        public bool CheckIfClickedVertice(Point point, out Vertice clickedVertice)
        {
            clickedVertice = null;
            foreach (var vertice in _vertices)
            {
                if (vertice.CheckIfClicked(point))
                {
                    clickedVertice = vertice;
                    return true;
                }
            }
            return false;
        }

        public bool CheckIfClickedEdge(Vertice selectedVertice, Vertice secondSelectedVertice, Point position)
        {
            if (selectedVertice.CalculateDistance(secondSelectedVertice.GetPosition()) + 3 >=
                (selectedVertice.CalculateDistance(position) + secondSelectedVertice.CalculateDistance(position)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfEdge(Vertice vertice1, Vertice vertice2)
        {
            if (Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == 1 ||
                Math.Abs(_vertices.IndexOf(vertice1) - _vertices.IndexOf(vertice2)) == _vertices.Count - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Draw()
        {
            if (_vertices.Count == 0)
                return;
            var points = _vertices;
            Color color;
            if (isSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            for (int i = 0; i < points.Count - 1; i++)
            {
                DrawLine(points[i].GetPosition(), points[i + 1].GetPosition(), color);
                points[i].Draw(_graphics);
            }
            DrawLine(points[points.Count - 1].GetPosition(), points[0].GetPosition(), color);
            points[points.Count - 1].Draw(_graphics);
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            foreach (var vertice in _vertices)
            {
                var position = new Point(endingPoint.X + (vertice.GetPosition().X - startingPoint.X),
                endingPoint.Y + (vertice.GetPosition().Y - startingPoint.Y));
                vertice.SetPosition(position);
            }
            if (_relation != null)
            {
                _relation.Execute();
            }
        }

        public int CheckOrder(Vertice firstVertice, Vertice secondVertice)
        {
            int indexOfFirst = _vertices.IndexOf(firstVertice);
            int indexOfSecond = _vertices.IndexOf(secondVertice);
            if (indexOfFirst == -1 || indexOfSecond == -1)
                return -1;
            if (indexOfFirst > indexOfSecond)
            {
                if (indexOfSecond == 0 && indexOfFirst == _vertices.Count - 1)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (indexOfFirst == 0 && indexOfSecond == _vertices.Count - 1)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
