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
        private bool _shapeMoving;
        private bool _verticeMoving;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HideAllOptions();
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _position = new Point(e.X, e.Y);
            ChangePositionTextBoxes();
            if (_newShape != null)
            {
                _selectedVertice = new Vertice(_position);
                _newShape.UpdateShape(_selectedVertice);
            }
            else if (_selectedVertice != null)
            {
                Polygon polygon = (Polygon)_selectedShape;
                UnSelectVertice();

                if (polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
                {
                    SelectVertice(clickedVertice);
                }
                else 
                {
                    if (!_selectedShape.CheckIfClicked(_position))
                        UnSelectShape();
                }
            }
            else if (_selectedShape != null)
            {
                if (CheckIfPolygon(_selectedShape))
                {
                    Polygon polygon = (Polygon)_selectedShape;
                    if (polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
                    {
                        SelectVertice(clickedVertice);
                    }
                    else if (_selectedShape.CheckIfClicked(_position))
                    {
                        _shapeMoving = true;
                    }
                    else
                    {
                        UnSelectShape();
                    }
                }
                else if (_selectedShape.CheckIfClicked(_position))
                {
                    _shapeMoving = true;
                }
                else
                {
                    UnSelectShape();
                }
            }
            else
            {
                SelectShape(_position);
            }
            SetOptionsForCorrectShape();
            DrawAllShapes();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_shapeMoving)
            {
                var position = new Point(e.X, e.Y);
                _selectedShape.Move(_position, position);
                _position = position;
                DrawAllShapes();
            }
            else if (_verticeMoving)
            {
                var position = new Point(e.X, e.Y);
                _selectedVertice.Move(_position, position);
                _position = position;
                DrawAllShapes();
            }

        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _shapeMoving = false;
            _verticeMoving = false;
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
                SetOptionsForCorrectShape();
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
                if (CheckIfPolygon(_selectedShape) && _selectedVertice != null)
                {
                    var shape = (Polygon)_selectedShape;
                    shape.Remove(_selectedVertice);
                }
                else
                {
                    _shapes.Remove(_selectedShape);
                }
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
            if (e.KeyCode == Keys.Enter && CheckIfCircle(_selectedShape))
            {
                var circle = (Circle)_selectedShape;
                circle.ChangeRadius(int.Parse(radiusTextBox.Text));
                DrawAllShapes();
            }
        }
    }
}
