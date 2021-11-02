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
    public class OrthogonalLines : IRelation
    {
        private Edge _firstEdge;
        private Edge _secondEdge;
        private int _directionFactor;
        public OrthogonalLines(Edge firstEdge, Edge secondEdge)
        {
            _firstEdge = firstEdge;
            _secondEdge = secondEdge;
            _directionFactor = calculateDirectionFactor(firstEdge);
            _firstEdge.SetRelation(this);
            _secondEdge.SetRelation(this);
            Execute();
        }

        public void DrawIcon(Graphics graphics)
        {
            Image img = (Image)(new Bitmap(Resources.perpendicular, new Size(20, 20)));
            graphics.DrawImage(img, (_firstEdge._firstVertice.GetPosition().X + _firstEdge._secondVertice.GetPosition().X) / 2,
                (_firstEdge._firstVertice.GetPosition().Y + _firstEdge._secondVertice.GetPosition().Y) / 2);
            graphics.DrawImage(img, (_secondEdge._firstVertice.GetPosition().X + _secondEdge._secondVertice.GetPosition().X) / 2,
                (_secondEdge._firstVertice.GetPosition().Y + _secondEdge._secondVertice.GetPosition().Y) / 2);
        }

        public int calculateDirectionFactor(Edge edge)
        {
            if (edge._secondVertice.GetPosition().X == edge._firstVertice.GetPosition().X)
                return 0;
            return (edge._secondVertice.GetPosition().Y - edge._firstVertice.GetPosition().Y)
                / (edge._secondVertice.GetPosition().X - edge._firstVertice.GetPosition().X);
        }

        public void Execute()
        {
            if (_directionFactor != calculateDirectionFactor(_firstEdge))
            {
                _directionFactor = calculateDirectionFactor(_firstEdge);
                var edgeLength = _secondEdge.GetLength();
                var firstPosition = _firstEdge._firstVertice.GetPosition();
                var secondPosition = _firstEdge._secondVertice.GetPosition();

                // Korzystając z wektorów wyznaczamy współczynnik kierunkowy, 
                // weźmy v = (x1, y1) - (x0, y0) oraz u = v / ||v||.
                (double X, double Y) v = (secondPosition.X - firstPosition.X, secondPosition.Y - firstPosition.Y);
                (double X, double Y) u = (v.X / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)), v.Y / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)));

                // Wyznaczamy współczynnik kierunkowy prostopadły.
                u = (-u.Y, u.X);

                // Wyznaczamy położenie szukanego punktu.
                // Punkt będzie znajdował się w położeniu(x0, y0) +du, gdzie d to odległość między punktami.
                var result = new Point(_secondEdge._firstVertice.GetPosition().X + (int)(edgeLength * u.X), 
                    _secondEdge._firstVertice.GetPosition().Y + (int)(edgeLength * u.Y));

                _secondEdge._secondVertice.SetPosition(result);
            }
            else if (calculateDirectionFactor(_secondEdge) == 0 || _directionFactor != (1 / calculateDirectionFactor(_secondEdge)))
            {
                _directionFactor = calculateDirectionFactor(_secondEdge);
                var edgeLength = _firstEdge.GetLength();
                var firstPosition = _secondEdge._firstVertice.GetPosition();
                var secondPosition = _secondEdge._secondVertice.GetPosition();

                // Korzystając z wektorów wyznaczamy współczynnik kierunkowy, 
                // weźmy v = (x1, y1) - (x0, y0) oraz u = v / ||v||.
                (double X, double Y) v = (secondPosition.X - firstPosition.X, secondPosition.Y - firstPosition.Y);
                (double X, double Y) u = (v.X / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)), v.Y / Math.Sqrt((v.X * v.X) + (v.Y * v.Y)));

                // Wyznaczamy współczynnik kierunkowy prostopadły.
                u = (-u.Y, u.X);

                // Wyznaczamy położenie szukanego punktu.
                // Punkt będzie znajdował się w położeniu(x0, y0) +du, gdzie d to odległość między punktami.
                var result = new Point(_firstEdge._firstVertice.GetPosition().X + (int)(edgeLength * u.X),
                    _firstEdge._firstVertice.GetPosition().Y + (int)(edgeLength * u.Y));

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
