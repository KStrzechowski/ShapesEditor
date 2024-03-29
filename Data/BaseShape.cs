﻿using ShapesEditor.Relations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesEditor.Data
{
    public abstract class BaseShape : IShape
    {
        protected IRelation _relation;
        public bool isSelected { protected get; set; }
        public bool _setRelation { protected get; set; }
        public static Graphics _graphics { get; set; }
        public static Bitmap _bitmap { get; set; }
        public static int _maxHeigth { get; set; }
        public static int _maxWidth { get; set; }
        public abstract void UpdateShape(Vertice vertice);
        public abstract bool CheckIfCorrect();
        public abstract bool CheckIfClicked(Point point);
        public abstract void Draw();
        public abstract void Move(Point startingPoint, Point endingPoint);

        public void Select()
        {
            isSelected = true;
            Draw();
        }
        public void UnSelect()
        {
            isSelected = false;
            Draw();
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

        public virtual void SetRelation(IRelation relation)
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
        }

        protected void DrawLine(Point first_point, Point second_point, Color color)
        {
            int d, dx, dy, a, b, xFactor, yFactor;
            int x = first_point.X, y = first_point.Y;

            // wybieramy poziomy kierunek rysowania
            if (first_point.X < second_point.X)
            {
                xFactor = 1;
                dx = second_point.X - first_point.X;
            }
            else
            {
                xFactor = -1;
                dx = first_point.X - second_point.X;
            }
            // wybieraym pionowy kierunek rysowania
            if (first_point.Y < second_point.Y)
            {
                yFactor = 1;
                dy = second_point.Y - first_point.Y;
            }
            else
            {
                yFactor = -1;
                dy = first_point.Y - second_point.Y;
            }
            // Sprawdzam czy linia nie wychodzi poza bitmapę
            if (_bitmap.Width > x && x >= 0 && _bitmap.Height > y && y >= 0)
            {
                _bitmap.SetPixel(x, y, color);
            }

            // sprawdzamy czy odcinek jest "bardziej" pionowy czy poziomy
            if (dx > dy)
            {
                a = (dy - dx) * 2;
                b = dy * 2;
                d = b - dx;
                // pętla po kolejnych x
                while (x != second_point.X)
                {
                    if (d >= 0)
                    {
                        x += xFactor;
                        y += yFactor;
                        d += a;
                    }
                    else
                    {
                        d += b;
                        x += xFactor;
                    }
                    if (_bitmap.Width > x && x >= 0 && _bitmap.Height > y && y >= 0)
                    {
                        _bitmap.SetPixel(x, y, color);
                    }
                }
            }
            else
            {
                a = (dx - dy) * 2;
                b = dx * 2;
                d = b - dy;
                // pętla po kolejnych y
                while (y != second_point.Y)
                {
                    if (d >= 0)
                    {
                        x += xFactor;
                        y += yFactor;
                        d += a;
                    }
                    else
                    {
                        d += b;
                        y += yFactor;
                    }
                    if (_bitmap.Width > x && x >= 0 && _bitmap.Height > y && y >= 0)
                    {
                        _bitmap.SetPixel(x, y, color);
                    }
                }
            }
        }
    }
}
