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
        private Vertice _selectedVertice;
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
            ChangePositionTextBoxes();
            if (_newShape != null)
            {
                _selectedVertice = new Vertice(_position);
                _newShape.UpdateShape(_selectedVertice);
                DrawAllShapes();
            }
            else 
            {
                SelectShape(_position);
            }
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnSelectShape();
            if (mainListBox.SelectedIndex == 0)
            {
                _newShape = new Polygon();
            }
            else if (mainListBox.SelectedIndex == 1)
            {
                _selectedVertice = new Vertice(new Point(100, 100));
                _newShape = new Circle(_selectedVertice, 50);
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
            UnSelectShape();
        }

        private void deleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (_selectedShape != null)
            {
                _shapes.Remove(_selectedShape);
                UnSelectShape();
            }
        }

        private void textBox_NumberValidation(object sender, CancelEventArgs e)
        {
            
        }

        private void positionTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _position.X = int.Parse(positionXTextBox.Text);
                _position.Y = int.Parse(positionYTextBox.Text);
                _selectedVertice.SetPosition(_position);
                DrawAllShapes();
            }
        }

        private void radiusTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _selectedShape.GetType() == typeof(Circle))
            {
                var circle = (Circle)_selectedShape;
                circle.ChangeRadius(int.Parse(radiusTextBox.Text));
                DrawAllShapes();
            }
        }
    }
}
