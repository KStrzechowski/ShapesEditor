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
        private Vertice _center;
        private int _radius;
        public Circle(Vertice center, int radius)
        {
            _center = center;
            _radius = radius;
        }
        public override void UpdateShape(Vertice vertice) => _center = vertice;

        public void ChangeRadius(int radius) => _radius = radius;
        public Point GetCenterPostion() => _center.GetPosition();

        public override bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(_center.GetPosition().X - point.X, 2) + Math.Pow(_center.GetPosition().Y - point.Y, 2))
                < Math.Pow(_radius, 2))
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
            Point center = _center.GetPosition();
            int radius = _radius; 
            Color color;
            if (isSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            _graphics.DrawEllipse(new Pen(color), center.X - radius, center.Y - radius, (radius * 2), (radius * 2));
            _center.Draw(_graphics);
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (_center.GetPosition().X - startingPoint.X),
                endingPoint.Y + (_center.GetPosition().Y - startingPoint.Y));
            _center.SetPosition(position);
        }
    }
}
