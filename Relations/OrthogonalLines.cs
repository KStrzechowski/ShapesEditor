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
        private int _a;
        public OrthogonalLines(Edge firstEdge, Edge secondEdge)
        {
            _firstEdge = firstEdge;
            _secondEdge = secondEdge;
            _a = (_firstEdge._secondVertice.GetPosition().Y - _firstEdge._firstVertice.GetPosition().Y) 
                / (_firstEdge._secondVertice.GetPosition().X - _firstEdge._firstVertice.GetPosition().X);
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

        public void Execute()
        {
            // Niestety nie udało się, algorytm nie działa poprawnie.
            
            /*if (_firstEdge._firstVertice.GetPosition().X == _firstEdge._secondVertice.GetPosition().X)
            {
                if (_secondEdge._firstVertice.GetPosition().Y != _secondEdge._secondVertice.GetPosition().Y)
                {
                    var firstPosition = _secondEdge._firstVertice.GetPosition();
                    var secondPosition = _secondEdge._secondVertice.GetPosition();
                    var edgeLength = (int)_secondEdge.GetLength();

                    if (firstPosition.Y > secondPosition.Y)
                    {
                        secondPosition.Y = firstPosition.Y - edgeLength;
                    }
                    else
                    {
                        secondPosition.Y = firstPosition.Y + edgeLength;
                    }
                    secondPosition.X = firstPosition.X;
                    _secondEdge._secondVertice.SetPosition(secondPosition);
                }
            }
            else if (_secondEdge._firstVertice.GetPosition().X == _secondEdge._secondVertice.GetPosition().X)
            {
                if (_firstEdge._firstVertice.GetPosition().Y != _firstEdge._secondVertice.GetPosition().Y)
                {
                    var firstPosition = _firstEdge._firstVertice.GetPosition();
                    var secondPosition = _firstEdge._secondVertice.GetPosition();
                    var edgeLength = (int)_firstEdge.GetLength();

                    if (firstPosition.Y > secondPosition.Y)
                    {
                        secondPosition.Y = firstPosition.Y - edgeLength;
                    }
                    else
                    {
                        secondPosition.Y = firstPosition.Y + edgeLength;
                    }
                    secondPosition.X = firstPosition.X;
                    _firstEdge._secondVertice.SetPosition(secondPosition);
                }
            }
            else if (_firstEdge._firstVertice.GetPosition().Y == _firstEdge._secondVertice.GetPosition().Y)
            {
                if (_secondEdge._firstVertice.GetPosition().X != _secondEdge._secondVertice.GetPosition().X)
                {

                }
            }
            else if (_secondEdge._firstVertice.GetPosition().Y == _secondEdge._secondVertice.GetPosition().Y)
            {
                if (_firstEdge._firstVertice.GetPosition().X != _firstEdge._secondVertice.GetPosition().X)
                {

                }
            }
            else
            {
                var firstPosition = _firstEdge._firstVertice.GetPosition();
                var secondPosition = _firstEdge._secondVertice.GetPosition();
                var a = (secondPosition.Y - firstPosition.Y) / (secondPosition.X - firstPosition.X);
                if (_a != a)
                {
                    var b = firstPosition.Y - a * firstPosition.X;
                    a = -1 / a;

                    firstPosition = _secondEdge._firstVertice.GetPosition();
                    var _edgeLength = _secondEdge.GetLength();
                    if (firstPosition.X < secondPosition.X)
                        secondPosition.X = (int)(firstPosition.X + _edgeLength / (Math.Sqrt(1 + a * a)));
                    else
                        secondPosition.X = (int)(firstPosition.X - _edgeLength / (Math.Sqrt(1 + a * a)));
                    secondPosition.Y = a * secondPosition.X + b;
                    _secondEdge._secondVertice.SetPosition(secondPosition);
                    _a = - 1 / a;
                    return;
                }


                firstPosition = _secondEdge._firstVertice.GetPosition();
                secondPosition = _secondEdge._secondVertice.GetPosition();
                a = (secondPosition.Y - firstPosition.Y) / (secondPosition.X - firstPosition.X);
                a = -1 / a;
                if (_a != a)
                {
                    var b = firstPosition.Y - a * firstPosition.X;

                    firstPosition = _firstEdge._firstVertice.GetPosition();
                    var _edgeLength = _firstEdge.GetLength();
                    if (firstPosition.X < secondPosition.X)
                        secondPosition.X = (int)(firstPosition.X + _edgeLength / (Math.Sqrt(1 + a * a)));
                    else
                        secondPosition.X = (int)(firstPosition.X - _edgeLength / (Math.Sqrt(1 + a * a)));
                    secondPosition.Y = a * secondPosition.X + b;
                    _firstEdge._secondVertice.SetPosition(secondPosition);
                    _a = - 1 / a;
                    return;
                }
            }*/



        }

        public void Remove()
        {
            _firstEdge.RemoveRelation();
            _secondEdge.RemoveRelation();
        }
    }
}
