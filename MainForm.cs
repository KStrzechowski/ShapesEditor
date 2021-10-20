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
        private readonly List<IShape> _shapes = new();
        private IShape _newShape;
        private IShape _selectedShape;
        private Point _position;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _position = new Point(e.X, e.Y);
            if (_newShape != null)
            {
                DrawAllShapes();
                _newShape.UpdateShape(_position);
            }
            else
            {
                SelectShape(_position);
            }
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnSelectAll();
            if (_newShape != null)
            {
                _shapes.Remove(_newShape);
            }
            if (mainListBox.SelectedIndex == 0)
            {
                _newShape = new Polygon();
            }
            else if (mainListBox.SelectedIndex == 1)
            {
                _newShape = new Circle();
            }
            if (_newShape != null)
            {
                _newShape.Select();
                _selectedShape = _newShape;
            }
        }

        private void addButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (_newShape != null)
            {
                _shapes.Add(_newShape);
                DrawAllShapes();
            }
            _newShape = null;
            mainListBox.SelectedIndex = -1;
        }
    }
}
