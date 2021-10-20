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
                if (shape.checkIfClicked(point))
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
                _selectedVertice = null;
                _newShape = null;
                mainListBox.SelectedIndex = -1;
            }
            DrawAllShapes();
        }

        private void ChangePositionTextBoxes()
        {
            positionXTextBox.Text = _position.X.ToString();
            positionYTextBox.Text = _position.Y.ToString();
        }


    }
}
