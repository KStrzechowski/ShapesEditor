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

        private void UnSelectShape()
        {
            if (_selectedShape != null)
            {
                _selectedShape.UnSelect();
                _selectedShape = null;
                _newShape = null;
                _shapeMoving = false;
                mainListBox.SelectedIndex = -1;
                UnSelectVertice();
                
                HideAllOptions();
            }
            DrawAllShapes();
        }

        private void UnSelectVertice()
        {
            _selectedVertice = null;
            _verticeMoving = false;
        }

        private void ChangePositionTextBoxes()
        {
            positionXTextBox.Text = _position.X.ToString();
            positionYTextBox.Text = _position.Y.ToString();
        }

        private void SetOptionsForCorrectShape()
        {
            HideAllOptions();
            if (_selectedShape != null)
            {
                if (CheckIfPolygon(_selectedShape))
                {
                    SelectedPolygon();
                }
                else if (CheckIfCircle(_selectedShape))
                {
                    SelectedCircle();
                }
                addButton.Visible = deleteButton.Visible = true;
            }
        }

        private void SelectedCircle()
        {
            radiusLabel.Visible = radiusTextBox.Visible = true;
            positionXTextBox.Visible = positionYTextBox.Visible = positionLabel.Visible = true;
        }

        private void SelectedPolygon()
        {
        }

        private void HideAllOptions()
        {
            radiusLabel.Visible = radiusTextBox.Visible = false;
            positionXTextBox.Visible = positionYTextBox.Visible = positionLabel.Visible = false;
            addButton.Visible = deleteButton.Visible = false;
        }

        private bool CheckIfCircle(IShape shape) => shape.GetType() == typeof(Circle);
        private bool CheckIfPolygon(IShape shape) => shape.GetType() == typeof(Polygon);
    }
}
