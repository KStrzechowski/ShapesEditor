using ShapesEditor.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Relations
{
    public interface IRelation
    {
        public void Execute();
        public void Remove();
        public void DrawIcon(Graphics graphics);
    }

}
