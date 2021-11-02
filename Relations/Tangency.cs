using ShapesEditor.Data;
using ShapesEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Relations
{
    public class Tangency : IRelation
    {
        private Circle _circle;
        private Edge _edge;
        public Tangency(Circle circle, Edge edge)
        {
            _circle = circle;
            _edge = edge;
            _circle.SetRelation(this);
            _edge.SetRelation(this);
            Execute();
        }

        public void DrawIcon(Graphics graphics)
        {
            Image img = (Image)(new Bitmap(Resources.radius, new Size(20, 20)));
            graphics.DrawImage(img, _circle.GetCenterPostion().X + 5, _circle.GetCenterPostion().Y + 5);
            graphics.DrawImage(img, (_edge._firstVertice.GetPosition().X + _edge._secondVertice.GetPosition().X) / 2,
                (_edge._firstVertice.GetPosition().Y + _edge._secondVertice.GetPosition().Y) / 2);
        }

        public void Execute()
        {
            var firstPosition = _edge._firstVertice.GetPosition();
            var secondPosition = _edge._secondVertice.GetPosition();
            var circlePosition = _circle.GetCenterPostion();
            if (secondPosition.X - firstPosition.X == 0)
            {
                _circle.SetRadius(Math.Abs(circlePosition.X - firstPosition.X));
            }
            else if (secondPosition.Y - firstPosition.Y == 0)
            {
                _circle.SetRadius(Math.Abs(circlePosition.Y - firstPosition.Y));
            }
            else
            {
                double a = (secondPosition.Y - firstPosition.Y) / (secondPosition.X - firstPosition.X);
                double b = firstPosition.Y - a * firstPosition.X;

                var d = (int)((Math.Abs(-a * circlePosition.X + circlePosition.Y - b) / Math.Sqrt(a * a + 1)));
                _circle.SetRadius(d);
            }
        }

        public void Remove()
        {
            _circle.RemoveRelation();
            _edge.RemoveRelation();
        }
    }
}
