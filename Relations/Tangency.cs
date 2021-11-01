using ShapesEditor.Data;
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
        }

        public void Execute()
        {
        }

        public void Remove()
        {
        }
    }
}
