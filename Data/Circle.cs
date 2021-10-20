using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Circle : BaseShape
    {
        private Point _center;
        private int _radius;
        public Circle()
        {
            _center = new Point(100, 100);
            _radius = 50;
        }
        public Circle(Point center, int radius)
        {
            _center = center;
            _radius = radius;
        }
        public override void UpdateShape(Point point)
        {
            _center = point;
            Draw();
        }

        public override void Draw()
        {
            Point center = _center;
            int radius = _radius; 
            Color color;
            if (isSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            _graphics.DrawEllipse(new Pen(color), center.X - radius, center.Y - radius, (radius * 2), (radius * 2));
            DrawVertice(center);
        }

        public override bool checkIfClicked(Point point)
        {
            if ((Math.Pow(_center.X - point.X, 2) + Math.Pow(_center.Y - point.Y, 2))
                < Math.Pow(_radius, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
