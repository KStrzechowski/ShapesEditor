using ShapesEditor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Structures
{
    public struct SelectedItems
    {
        public IShape shape { get; set; }
        public Vertice vertice { get; set; }
        public Edge edge { get; set; }
        public IShape secondShape { get; set; }
        public Edge secondEdge { get; set; }

        public SelectedItems UnSelect()
        {
            if (shape != null)
                shape.UnSelect();
            if (vertice != null)
                vertice.UnSelect();
            if (edge != null)
                edge.UnSelect();
            if (secondEdge != null)
                secondEdge.UnSelect();
            if (secondShape != null)
                secondShape.UnSelect();

            return new SelectedItems();
        }
    }
}
