using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public interface IShape
    {
        public void UpdateShape(Vertice vertice);
        public void Draw();
        public void Select();
        public void UnSelect();
        public bool checkIfClicked(Point point);
        public Vertice SelectVertice();
    }
}
