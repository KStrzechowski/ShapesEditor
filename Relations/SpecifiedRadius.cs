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
    class SpecifiedRadius : IRelation
    {
        private Circle _circle;
        private int _radius;
        public SpecifiedRadius(Circle circle)
        {
            _circle = circle;
            _radius = _circle.GetRadius();
            _circle.SetRelation(this);
            Execute();
        }

        public void DrawIcon(Graphics graphics)
        {
            Image img = (Image)(new Bitmap(Resources.radius, new Size(20, 20)));
            graphics.DrawImage(img, _circle.GetCenterPostion().X + 5, _circle.GetCenterPostion().Y + 5);
        }

        public void Execute()
        {
            _circle.SetRadius(_radius);
        }

        public void Remove()
        {
            _circle.RemoveRelation();
        }
    }
}
