using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesEditor.Drawing;

namespace ShapesEditor.Data
{
    public class Polygon : IShape
    {
        private readonly List<Point> _vertices;
        public Polygon(List<Point> vertices)
        {
            _vertices = vertices;
        }

        public List<Point> GetVertices() => _vertices;

        public void Draw()
        {
            DrawShape.Draw(this);
        }

        public void UpdateShape(Point point)
        {
            _vertices.Add(point);
        }
    }
}
