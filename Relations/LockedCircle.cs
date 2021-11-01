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
    class LockedCircle : IRelation
    {
        private Circle _circle;
        private Point _center;
        public  LockedCircle(Circle circle)
        {
            _circle = circle;
            _center = _circle.GetCenterPostion();
            _circle.SetRelation(this);
            Execute();
        }

        public void DrawIcon(Graphics graphics)
        {
            Image img = (Image)(new Bitmap(Resources._lock, new Size(10, 10)));
            graphics.DrawImage(img, _center.X + 5, _center.Y + 5);
        }

        public void Execute()
        {
            _circle.SetCenterPosition(_center);
        }

        public void Remove()
        {
            _circle.RemoveRelation();
        }

    }
}
