using ShapesEditor.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Vertice
    {
        private Point _position;
        private bool _isSelected;
        private IRelation _relation;
        private (IRelation previous, IRelation next) _edgeRelations;
        public Vertice(Point point)
        {
            _position = point;
        }

        public void SetPosition(Point point) => _position = point;
        public Point GetPosition() => _position;
        public void Select() => _isSelected = true;
        public void UnSelect() => _isSelected = false;

        public double CalculateDistance(Point point)
        {
            return Math.Floor((Math.Sqrt(Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2))));
        }

        public bool CheckIfClicked(Point point)
        {
            if ((Math.Pow(GetPosition().X - point.X, 2) + Math.Pow(GetPosition().Y - point.Y, 2)) < 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Draw(Graphics graphics)
        {
            int radius = 5;
            if (_isSelected)
            {
                graphics.FillEllipse(new SolidBrush(Color.Green), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
            }
            else
            {
                graphics.FillEllipse(new SolidBrush(Color.Orange), GetPosition().X - radius, GetPosition().Y - radius, radius * 2, radius * 2);
            }
        }

        public void Move(Point startingPoint, Point endingPoint)
        {
            var position = new Point(endingPoint.X + (GetPosition().X - startingPoint.X),
                endingPoint.Y + (GetPosition().Y - startingPoint.Y));
            SetPosition(position);
            ExecuteRelation();
        }

        // Usuwamy całą relację i referencje na nią
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
            _relation = null;
        }

        public void SetRelation(IRelation relation)
        {
            if (_relation != null)
            {
                _relation.Remove();
            }
            _relation = relation;
        }

        public void ExecuteRelation()
        {
            if (_relation != null)
            {
                _relation.Execute();
            }
            if (_edgeRelations.previous != null)
            {
                _edgeRelations.previous.Execute();
            }
            if (_edgeRelations.next != null)
            {
                _edgeRelations.next.Execute();
            }
        }

        public void SetPreviousEdgeRelation(IRelation relation) => _edgeRelations.previous = relation;
        public void SetNextEdgeRelation(IRelation relation) => _edgeRelations.next = relation;

    }
}
