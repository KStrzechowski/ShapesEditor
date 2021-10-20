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
        public Vertice(Point point)
        {
            _position = point;
        }

        public void SetPosition(Point point) => _position = point;
        public Point GetPosition() => _position;
    }
}
