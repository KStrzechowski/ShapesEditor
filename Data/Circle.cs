using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapesEditor.Drawing;

namespace ShapesEditor.Data
{
    public class Circle : IShape
    {
        private Point _center;
        private double _radius;
        public Circle(Point center, double radius)
        {
            _center = center;
            _radius = radius;
        }

        public Point GetCentrum() => _center;
        public double GetRadius() => _radius;

        public void Draw()
        {
            DrawShape.Draw(this);
        }

        public void UpdateShape(Point point)
        {
            _center = point;
        }
    }
}
