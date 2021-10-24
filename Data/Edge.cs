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
        private IRelation _relation;

        public Edge(Vertice firstVertice, Vertice secondVertice, Polygon polygon = null)
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

        public void DeleteRelation()
        {
            if (_relation != null)
            {
                _relation.Remove();
            }
        }

        // Usuwamy referencję na relację
        public void RemoveRelation()
        {
            _firstVertice.SetNextEdgeRelation(null);
            _secondVertice.SetPreviousEdgeRelation(null);
            _relation = null;
        }

        public void SetRelation(IRelation relation)
        {
            if (_relation != null)
            {
                _relation.Remove();
            }
            _relation = relation;
            _firstVertice.SetNextEdgeRelation(relation);
            _secondVertice.SetPreviousEdgeRelation(relation);
        }

        public void ExecuteRelation()
        {
            if (_relation != null)
            {
                _relation.Execute();
            }
        }
    }
}
