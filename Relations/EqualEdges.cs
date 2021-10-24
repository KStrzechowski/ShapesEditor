using ShapesEditor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Relations
{
    public class EqualEdges : IRelation
    {
        private Edge _firstEdge;
        private Edge _secondEdge;
        private double _edgeLength;
        public EqualEdges(Edge firstEdge, Edge secondEdge)
        {
            _firstEdge = firstEdge;
            _secondEdge = secondEdge;
            _firstEdge.SetRelation(this);
            _secondEdge.SetRelation(this);
        }

        public void Execute()
        {
            if (_firstEdge.GetLength() != _edgeLength)
            {
                _edgeLength = _firstEdge.GetLength();
                var firstPosition = _secondEdge._firstVertice.GetPosition();
                var secondPosition = _secondEdge._secondVertice.GetPosition();

                // Wyznaczamy wzór prostej na której ułożona jest krawędź którą musimy zmienić.
                var a = (secondPosition.Y - firstPosition.Y) / (secondPosition.X - firstPosition.X);
                var b = firstPosition.Y - a * firstPosition.X;

                // Wyznaczamy nowe współrzędne dla drugiego wierzchołka krawędzi.
                secondPosition.X = (int)(firstPosition.X + _edgeLength / (Math.Sqrt(1 + a * a)));
                secondPosition.Y = a * secondPosition.X + b;
                _secondEdge._secondVertice.SetPosition(secondPosition);
            }
            else if (_secondEdge.GetLength() != _edgeLength)
            {
                _edgeLength = _secondEdge.GetLength();
                var firstPosition = _firstEdge._firstVertice.GetPosition();
                var secondPosition = _firstEdge._secondVertice.GetPosition();

                // Wyznaczamy wzór prostej na której ułożona jest krawędź którą musimy zmienić.
                var a = (secondPosition.Y - firstPosition.Y) / (secondPosition.X - firstPosition.X);
                var b = firstPosition.Y - a * firstPosition.X;

                // Wyznaczamy nowe współrzędne dla drugiego wierzchołka krawędzi.
                secondPosition.X = (int)(firstPosition.X + _edgeLength / (Math.Sqrt(1 + a * a)));
                secondPosition.Y = a * secondPosition.X + b;
                _firstEdge._secondVertice.SetPosition(secondPosition);
            }
        }

        public void Remove()
        {
            _firstEdge.RemoveRelation();
            _secondEdge.RemoveRelation();
        }
    }
}
