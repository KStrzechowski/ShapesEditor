using ShapesEditor.Data;
using ShapesEditor.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            Execute();
        }

        public void DrawIcon(Graphics graphics)
        {
            Image img = (Image)(new Bitmap(Resources.twoLines, new Size(20, 20)));
            graphics.DrawImage(img, (_firstEdge._firstVertice.GetPosition().X + _firstEdge._secondVertice.GetPosition().X) / 2,
                (_firstEdge._firstVertice.GetPosition().Y + _firstEdge._secondVertice.GetPosition().Y) / 2);
            graphics.DrawImage(img, (_secondEdge._firstVertice.GetPosition().X + _secondEdge._secondVertice.GetPosition().X) / 2,
                (_secondEdge._firstVertice.GetPosition().Y + _secondEdge._secondVertice.GetPosition().Y) / 2);
        }

        public void Execute()
        {
            if (_firstEdge.GetLength() != _edgeLength)
            {
                _edgeLength = _firstEdge.GetLength();
                var firstPosition = _secondEdge._firstVertice.GetPosition();
                var secondPosition = _secondEdge._secondVertice.GetPosition();

                // Wyznaczamy położenie drugiego punktu korzystając z wektorów.
                // weźmy v = (x1, y1) - (x0, y0) oraz u = v / ||v||.
                // Wtedy szukany punkt będzie znajdował się w położeniu (x0, y0) + du, gdzie d to odległość między punktami.
                (double X, double Y) v = (secondPosition.X - firstPosition.X, secondPosition.Y - firstPosition.Y);
                (double X, double Y) u = (v.X / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)), v.Y / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)));

                var result = new Point(firstPosition.X + (int)(_edgeLength * u.X), firstPosition.Y + (int)(_edgeLength * u.Y));
                _secondEdge._secondVertice.SetPosition(result);
            }
            else if (_secondEdge.GetLength() != _edgeLength)
            {
                _edgeLength = _secondEdge.GetLength();
                var firstPosition = _firstEdge._firstVertice.GetPosition();
                var secondPosition = _firstEdge._secondVertice.GetPosition();

                (double X, double Y) v = (secondPosition.X - firstPosition.X, secondPosition.Y - firstPosition.Y);
                (double X, double Y) u = (v.X / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)), v.Y / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)));

                var result = new Point(firstPosition.X + (int)(_edgeLength * u.X), firstPosition.Y + (int)(_edgeLength * u.Y));
                _firstEdge._secondVertice.SetPosition(result);
            }
        }

        public void Remove()
        {
            _firstEdge.RemoveRelation();
            _secondEdge.RemoveRelation();
        }
    }
}
