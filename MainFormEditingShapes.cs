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
            if (_selectedEdge != null && !_selectingSecondEdge)
            {
                UnSelectEdge();
            }
        }

        private void UnSelectEdge()
        {
            _selectedEdge._secondVertice.UnSelect();
            _selectedEdge._firstVertice.UnSelect();
            _selectedEdge = null;
            _edgeMoving = false;
        }

        private void SetOptionsForCorrectShape()
        {
            HideAllOptions();
            if (_newShape != null)
            {
                addButton.Enabled = true;
            }
            if (_selectedShape != null)
            {
                deleteButton.Enabled = true;
                deleteRelationButton.Enabled = true;
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
            radiusLabel.Enabled = radiusTextBox.Enabled = true;
            positionXTextBox.Enabled = positionYTextBox.Enabled = positionLabel.Enabled = true;
            lockCircleButton.Enabled = LockLengthButton.Enabled = true;
        }

        private void SelectedPolygon()
        {
            if (_selectedVertice != null)
            {
                if (_selectedEdge != null)
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
            positionXTextBox.Enabled = positionYTextBox.Enabled = positionLabel.Enabled = true;
        }

        private void SelectedEdge()
        {
            addButton.Enabled = true;
            deleteButton.Enabled = false;
            equalLengthsButton.Enabled = orthogonalButton.Enabled = tangencyButton.Visible = true;
            LockLengthButton.Enabled = true;
        }

        private void HideAllOptions()
        {
            radiusLabel.Enabled = radiusTextBox.Enabled = false;
            positionXTextBox.Enabled = positionYTextBox.Enabled = positionLabel.Enabled = false;
            addButton.Enabled = deleteButton.Enabled = false;
            lockCircleButton.Enabled = LockLengthButton.Enabled = false;
            equalLengthsButton.Enabled = orthogonalButton.Enabled = tangencyButton.Enabled = false;
            deleteRelationButton.Enabled = false;
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
