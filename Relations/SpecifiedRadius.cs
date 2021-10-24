using ShapesEditor.Data;
using System;
using System.Collections.Generic;
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
