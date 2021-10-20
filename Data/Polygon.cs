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
        private readonly List<Point> _vertices;
        public Polygon()
        {
            _vertices = new List<Point>();
        }
        public Polygon(List<Point> vertices)
        {
            _vertices = vertices;
        }

        public override void UpdateShape(Point point)
        {
            _vertices.Add(point);
            Draw();
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
                DrawLine(points[i], points[i + 1], color);
                DrawVertice(points[i]);
            }
            DrawLine(points[points.Count - 1], points[0], color);
            DrawVertice(points[points.Count - 1]);
        }

        public override bool checkIfClicked(Point point)
        {
            bool result = false;
            int j = _vertices.Count() - 1;
            for (int i = 0; i < _vertices.Count(); i++)
            {
                if (_vertices[i].Y < point.Y && _vertices[j].Y >= point.Y 
                    || _vertices[j].Y < point.Y && _vertices[i].Y >= point.Y)
                {
                    if (_vertices[i].X + (point.Y - (float)_vertices[i].Y) / ((float)_vertices[j].Y - _vertices[i].Y) * (_vertices[j].X - _vertices[i].X) 
                        < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}
