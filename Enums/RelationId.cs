using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Enums
{
    public enum RelationId
    {
        Default = -1,
        LockedCircle,
        SpecifiedRadius,
        SpecifiedEdge,
        EqualEdges,
        OrthogonalLines,
        Tangency
    }
}
