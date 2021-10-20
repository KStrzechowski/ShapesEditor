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
            foreach (var shape in _shapes)
            {
                shape.Draw();
            }
        }

        private void SelectShape(Point point)
        {
            UnSelectAll();
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

        private void UnSelectAll()
        {
            foreach (var shape in _shapes)
            {
                shape.UnSelect();
            }
            DrawAllShapes();
        }
    }
}
