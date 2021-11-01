using ShapesEditor.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public interface IShape
    {
        public void UpdateShape(Vertice vertice);
        public bool CheckIfCorrect();
        public void Select();
        public void UnSelect();
        public bool CheckIfClicked(Point point);
        public void Draw();
        public void Move(Point startingPoint, Point endingPoint);
        public void SetRelation(IRelation relation);
        // Usuwamy całą relację i referencje na nią
        public void DeleteRelation();
        // Usuwamy referencję na relację
        public void RemoveRelation();
        public void ExecuteRelation();
    }
}
