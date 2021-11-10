using ShapesEditor.Relations;
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

        public override bool CheckIfCorrect() => _radius > 0;

        public void SetRadius(int radius) => _radius = radius;
        public int GetRadius() => _radius;
        public Point GetCenterPostion() => _center.GetPosition();
        public void SetCenterPosition(Point point) => _center.SetPosition(point);

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
                color = Color.DarkGray;

            DrawArch(radius, color);
            _center.Draw(_graphics);
        }

        public void DrawArch(int r, Color color)
        {
            Point center = GetCenterPostion();
            int y = 0;
            int x = r;
            double d = 0;
            if (center.X + x > 0 && _bitmap.Width > center.X + x && center.Y> 0 && _bitmap.Height > center.Y)
            {
                _bitmap.SetPixel(center.X + x, center.Y, color);
                _bitmap.SetPixel(center.X + x - 1, center.Y + y, color);
            }
            if (center.X - x > 0 && _bitmap.Width > center.X - x && center.Y > 0 && _bitmap.Height > center.Y)
            {
                _bitmap.SetPixel(center.X - x, center.Y, color);
                _bitmap.SetPixel(center.X - x - 1, center.Y + y, color);
            }

            while (x > y)
            {
                y++;
                if (Distance(r, y) < d) x--;
                Color color1 = Color.FromArgb(color.A, (int)(color.R * (1 - Distance(r, y))),
                    (int)(color.G * (1 - Distance(r, y))), (int)(color.B * (1 - Distance(r, y))));
                Color color2 = Color.FromArgb(color.A, (int)(color.R * Distance(r, y)),
                    (int)(color.G * Distance(r, y)), (int)(color.B * Distance(r, y)));
                DrawPixels(center, x, y, color1, color2, r);
                DrawPixels(center, -x, y, color1, color2, r);
                DrawPixels(center, x, -y, color1, color2, r);
                DrawPixels(center, -x, -y, color1, color2, r);
                DrawPixels(center, y, x, color1, color2, r);
                DrawPixels(center, -y, x, color1, color2, r);
                DrawPixels(center, y, -x, color1, color2, r);
                DrawPixels(center, -y, -x, color1, color2, r);

                d = Distance(r, y);
            }
        }

        public void DrawPixels(Point center, int x, int y, Color color1 , Color color2, int r)
        {
            if (center.X + x > 0 && _bitmap.Width > center.X + x && center.Y + y > 1 && _bitmap.Height > center.Y + y)
            {
                _bitmap.SetPixel(center.X + x, center.Y + y, color1);
                _bitmap.SetPixel(center.X + x - 1, center.Y + y, color2);
                _bitmap.SetPixel(center.X + x, center.Y + y - 1, color2);
            }
        }

        public double Distance(int r, int y)
        {
            double x = Math.Sqrt(r * r - y * y);
            return Math.Ceiling(x) - x;
        }

        public override void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (_center.GetPosition().X - startingPoint.X),
            endingPoint.Y + (_center.GetPosition().Y - startingPoint.Y));
            _center.SetPosition(position);
            if (_relation != null)
            {
                _relation.Execute();
            }
        }

        public override void SetRelation(IRelation relation)
        {
            _center.SetRelation(relation);
            base.SetRelation(relation);
        }
    }
}
