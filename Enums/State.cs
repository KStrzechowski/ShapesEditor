using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Enums
{
    public enum State
    {
        Default = -1,
        NewShape,
        SelectedShape,
        SelectedVertice,
        SelectedEdge,
        MoveShape,
        MoveVertice,
        MoveEdge,
        SelectingSecondEdge,
        SelectingCircle
    }
}
