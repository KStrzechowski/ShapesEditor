using ShapesEditor.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Relations
{
    class SpecifiedEdge : IRelation
    {
        private Edge _edge;
        private Point _firstPosition;
        private Point _secondPosition;
        private double _edgeLength;
        public SpecifiedEdge(Edge edge)
        {
            _edge = edge;
            _firstPosition = edge._firstVertice.GetPosition();
            _secondPosition = edge._secondVertice.GetPosition();
            _edgeLength = edge.GetLength();
            _edge.SetRelation(this);
        }

        public void Execute()
        {
            if (_edge.GetLength() != _edgeLength)
            {
                if (!_edge._firstVertice.GetPosition().Equals(_firstPosition))
                {
                    var xDistance = _edge._firstVertice.GetPosition().X - _firstPosition.X;
                    var yDistance = _edge._firstVertice.GetPosition().Y - _firstPosition.Y;
                    var position = new Point(_edge._secondVertice.GetPosition().X + xDistance,
                        _edge._secondVertice.GetPosition().Y + yDistance);

                    _edge._secondVertice.SetPosition(position);
                }
                else
                {
                    var xDistance = _edge._secondVertice.GetPosition().X - _secondPosition.X;
                    var yDistance = _edge._secondVertice.GetPosition().Y - _secondPosition.Y;
                    var position = new Point(_edge._firstVertice.GetPosition().X + xDistance,
                        _edge._firstVertice.GetPosition().Y + yDistance);

                    _edge._firstVertice.SetPosition(position);
                }
            }
            _firstPosition = _edge._firstVertice.GetPosition();
            _secondPosition = _edge._secondVertice.GetPosition();
        }

        public void Remove()
        {
            _edge.RemoveRelation();
        }
    }
}
