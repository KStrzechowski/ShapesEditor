using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Vertice
    {
        private Point _position;
        private bool _isSelected;
        public Vertice(Point point)
        {
            _position = point;
        }

        public void SetPosition(Point point) => _position = point;
        public Point GetPosition() => _position;
        public void Select() => _isSelected = true;
        public void UnSelect() => _isSelected = false;

        public double CalculateDistance(Point point)
        {
            return (Math.Sqrt(Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2)));
        }

        public bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2)) < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(Graphics graphics)
        {
            int radius = 5;
            if (_isSelected)
            {
                graphics.FillEllipse(new SolidBrush(Color.Green), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
            }
            else
            {
                graphics.FillEllipse(new SolidBrush(Color.Orange), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
            }
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (GetPosition().X - startingPoint.X),
                endingPoint.Y + (GetPosition().Y - startingPoint.Y));
            SetPosition(position);
        }
    }
}
