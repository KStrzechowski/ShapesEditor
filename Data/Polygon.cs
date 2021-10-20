using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public class Polygon : BaseShape
    {
        private readonly List<Vertice> _vertices;
        public Polygon()
        {
            _vertices = new List<Vertice>();
        }

        public override void UpdateShape(Vertice vertice)
        {
            _vertices.Add(vertice);
        }

        public override void Draw()
        {
            if (_vertices.Count == 0)
                return;
            var points = _vertices;
            Color color;
            if (isSelected)
                color = Color.Blue;
            else
                color = Color.Black;

            for (int i = 0; i < points.Count - 1; i++)
            {
                DrawLine(points[i].GetPosition(), points[i + 1].GetPosition(), color);
                DrawVertice(points[i].GetPosition());
            }
            DrawLine(points[points.Count - 1].GetPosition(), points[0].GetPosition(), color);
            DrawVertice(points[points.Count - 1].GetPosition());
        }

        public override bool checkIfClicked(Point point)
        {
            bool result = false;
            int j = _vertices.Count() - 1;
            for (int i = 0; i < _vertices.Count(); i++)
            {
                if (_vertices[i].GetPosition().Y < point.Y && _vertices[j].GetPosition().Y >= point.Y 
                    || _vertices[j].GetPosition().Y < point.Y && _vertices[i].GetPosition().Y >= point.Y)
                {
                    if (_vertices[i].GetPosition().X + (point.Y - 
                        (float)_vertices[i].GetPosition().Y) / ((float)_vertices[j].GetPosition().Y - 
                        _vertices[i].GetPosition().Y) * (_vertices[j].GetPosition().X - _vertices[i].GetPosition().X) 
                        < point.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }

        public override Vertice SelectVertice()
        {
            return _vertices.Last();
        }
    }
}
