using ShapesEditor.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Edge
    {
        public Vertice _firstVertice { get; private set; }
        public Vertice _secondVertice { get; private set; }
        private Polygon _polygon;
        private IRelation _relation;

        public Edge(Vertice firstVertice, Vertice secondVertice, Polygon polygon)
        {
            if (polygon != null)
            {
                int order = polygon.CheckOrder(firstVertice, secondVertice);
                if (order == 1)
                {
                    _secondVertice = firstVertice;
                    _firstVertice = secondVertice;
                }
                else
                {
                    _firstVertice = firstVertice;
                    _secondVertice = secondVertice;
                }
                _polygon = polygon;
            }
            else
            {
                _firstVertice = firstVertice;
                _secondVertice = secondVertice;
            }
        }

        public double GetLength() => _firstVertice.CalculateDistance(_secondVertice.GetPosition());

        public bool CheckIfClicked(Point position)
        {
            if (GetLength() + 3 >= (_firstVertice.CalculateDistance(position) 
                + _secondVertice.CalculateDistance(position)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            _firstVertice.Move(startingPoint, endingPoint);
            _secondVertice.Move(startingPoint, endingPoint);
            if (_relation != null)
            {
                _relation.Execute();
            }
        }

        public void Select()
        {
            _firstVertice.Select();
            _secondVertice.Select();
        }

        public void UnSelect()
        {
            _firstVertice.UnSelect();
            _secondVertice.UnSelect();
        }

        public void DeleteRelation()
        {
            _polygon.DeleteRelation(this);
        }

        // Usuwamy referencję na relację
        public void RemoveRelation()
        {
            _polygon.RemoveRelation(this);
            _relation = null;
        }

        public void SetRelation(IRelation relation)
        {
            if (_relation != null)
            {
                _relation.Remove();
            }
            _relation = relation;
            _polygon.AddRelation(this, _relation);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(Edge))
            {
                var edge = (Edge)obj;
                if ((_firstVertice == edge._firstVertice && _secondVertice == edge._secondVertice) ||
                    (_firstVertice == edge._secondVertice && _secondVertice == edge._firstVertice))
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashCode = _firstVertice.GetHashCode() * _secondVertice.GetHashCode();
            if (_relation != null)
                hashCode *= _relation.GetHashCode();
            return hashCode;
        }
    }
}
