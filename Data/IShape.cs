using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    interface IShape
    {
        public void Draw();
        public void UpdateShape(Point point);
    }
}
