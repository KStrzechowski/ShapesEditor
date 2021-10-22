using ShapesEditor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShapesEditor
{
    public partial class MainForm : Form
    {
        private void SetBitmap()
        {
            mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            BaseShape._bitmap = (Bitmap)mainPictureBox.Image;
            BaseShape._graphics = Graphics.FromImage(mainPictureBox.Image);
        }

        private void DrawAllShapes()
        {
            SetBitmap();
            if (_selectedShape != null)
                _selectedShape.Draw();
            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
        }

        private void SelectShape(Point point)
        {
            UnSelectShape();
            foreach (var shape in _shapes)
            {
                if (shape.CheckIfClicked(point))
                {
                    shape.Select();
                    _selectedShape = shape;
                    break;
                }
            }
        }

        private void SelectVertice(Vertice vertice)
        {
            _selectedVertice = vertice;
            _selectedVertice.Select();
            _verticeMoving = true;
        }

        private void SelectEdge(Vertice vertice)
        {
            _secondSelectedVertice = vertice;
            _secondSelectedVertice.Select();
        }

        private void MoveEdge()
        {

        }

        private void UnSelectShape()
        {
            if (_selectedShape != null)
            {
                _selectedShape.UnSelect();
                _selectedShape = null;
                _newShape = null;
                _shapeMoving = false;
                mainListBox.SelectedIndex = -1;
                if (_selectedVertice != null)
                {
                    UnSelectVertice();
                }

                HideAllOptions();
            }
            DrawAllShapes();
        }

        private void UnSelectVertice()
        {
            _selectedVertice.UnSelect();
            _selectedVertice = null;
            _verticeMoving = false;
            if (_secondSelectedVertice != null)
            {
                UnSelectEdge();
            }
        }

        private void UnSelectEdge()
        {
            _secondSelectedVertice.UnSelect();
            _secondSelectedVertice = null;
            _edgeMoving = false;
        }

        private void SetOptionsForCorrectShape()
        {
            HideAllOptions();
            if (_newShape != null)
            {
                addButton.Visible = true;
            }
            if (_selectedShape != null)
            {
                deleteButton.Visible = true;
                if (CheckIfPolygon(_selectedShape))
                {
                    SelectedPolygon();
                }
                else if (CheckIfCircle(_selectedShape))
                {
                    SelectedCircle();
                }
            }
        }

        private void SelectedCircle()
        {
            radiusLabel.Visible = radiusTextBox.Visible = true;
            positionXTextBox.Visible = positionYTextBox.Visible = positionLabel.Visible = true;
        }

        private void SelectedPolygon()
        {
            if (_selectedVertice != null)
            {
                if (_secondSelectedVertice != null)
                {
                    SelectedEdge();
                }
                else
                {
                    SelectedVertice();
                }
            }
        }

        private void SelectedVertice()
        {
            positionXTextBox.Visible = positionYTextBox.Visible = positionLabel.Visible = true;
        }

        private void SelectedEdge()
        {
            addButton.Visible = true;
            deleteButton.Visible = false;
        }

        private void HideAllOptions()
        {
            radiusLabel.Visible = radiusTextBox.Visible = false;
            positionXTextBox.Visible = positionYTextBox.Visible = positionLabel.Visible = false;
            addButton.Visible = deleteButton.Visible = false;
        }

        private void ChangePositionTextBoxes(Point position)
        {
            positionXTextBox.Text = position.X.ToString();
            positionYTextBox.Text = position.Y.ToString();
        }

        private bool CheckIfCircle(IShape shape) => shape.GetType() == typeof(Circle);
        private bool CheckIfPolygon(IShape shape) => shape.GetType() == typeof(Polygon);
    }
}
