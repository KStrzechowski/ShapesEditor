using ShapesEditor.Data;
using ShapesEditor.Relations;
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
        private Point _position;
        private IShape _selectedShape;
        private Vertice _selectedVertice;
        private Edge _selectedEdge;
        private Edge _secondEdge;
        private bool _shapeMoving;
        private bool _verticeMoving;
        private bool _edgeMoving;
        private bool _selectingSecondEdge;

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
            ChangePositionTextBoxes(_position);
            if (_selectingSecondEdge)
            {
                if (_selectedVertice != null)
                {
                    Polygon polygon = (Polygon)_selectedShape;

                    if (polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
                    {
                        if (polygon.CheckIfEdge(_selectedVertice, clickedVertice))
                        {
                            clickedVertice.Select();
                            _secondEdge = new Edge(_selectedVertice, clickedVertice, (Polygon)_selectedShape);
                            if (_secondEdge._firstVertice == _selectedEdge._firstVertice &&
                                _secondEdge._secondVertice == _selectedEdge._secondVertice)
                            {
                                _selectedEdge = null;
                                _selectedVertice = null;
                            }
                            else
                            {
                                new EqualEdges(_selectedEdge, _secondEdge);
                                _selectingSecondEdge = false;
                            }
                        }
                        else
                        {
                            UnSelectVertice();
                            SelectVertice(clickedVertice);
                        }
                    }
                    else
                    {
                        UnSelectVertice();
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
 
                        else
                        {
                            UnSelectShape();
                        }
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
                DrawAllShapes();
                return;
            }

            if (_newShape != null)
            {
                _selectedVertice = new Vertice(_position);
                _newShape.UpdateShape(_selectedVertice);
            }
            else if (_selectedEdge != null)
            {
                if (_selectedEdge.CheckIfClicked(_position))
                { 
                    _edgeMoving = true;
                }
                else
                {
                    UnSelectVertice();
                    if (!_selectedShape.CheckIfClicked(_position))
                        UnSelectShape();
                }

            }
            else if (_selectedVertice != null)
            {
                Polygon polygon = (Polygon)_selectedShape;

                if (polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
                {
                    if (polygon.CheckIfEdge(_selectedVertice, clickedVertice))
                    {
                        clickedVertice.Select();
                        _selectedEdge = new Edge(_selectedVertice, clickedVertice, (Polygon)_selectedShape);
                    }
                    else
                    {
                        UnSelectVertice();
                        SelectVertice(clickedVertice);
                    }
                }
                else 
                {
                    UnSelectVertice();
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
                _shapeMoving = true;
            }
            SetOptionsForCorrectShape();
            DrawAllShapes();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_shapeMoving)
            {
                if (_selectedShape == null)
                {
                    _shapeMoving = false;
                    return;
                }
                var position = new Point(e.X, e.Y);
                _selectedShape.Move(_position, position);
                _position = position;
                if (CheckIfCircle(_selectedShape))
                {
                    Circle circle = (Circle)_selectedShape;
                    ChangePositionTextBoxes(circle.GetCenterPostion());
                }
                _selectedShape.ExecuteRelation();
                DrawAllShapes();
            }
            else if (_verticeMoving)
            {
                _selectedVertice.ExecuteRelation();
                var position = new Point(e.X, e.Y);
                _selectedVertice.Move(_position, position);
                _position = position;
                _selectedVertice.ExecuteRelation();
                ChangePositionTextBoxes(_selectedVertice.GetPosition());
                DrawAllShapes();
            }
            else if (_edgeMoving)
            {
                var position = new Point(e.X, e.Y);
                _selectedEdge.Move(_position, position);
                _position = position;
                _selectedEdge.ExecuteRelation();
                DrawAllShapes();
            }
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectedEdge != null)
            {
                _selectedEdge.ExecuteRelation();
            }
            if (_selectedVertice != null)
            {
                _selectedVertice.ExecuteRelation();
            }
            if (_selectedShape != null)
            {
                _selectedShape.ExecuteRelation();
            }
            _shapeMoving = false;
            _verticeMoving = false;
            _edgeMoving = false;
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
            else if (_selectedEdge != null)
            {
                var polygon = (Polygon)_selectedShape;
                polygon.AddVertice(_selectedEdge._firstVertice, _selectedEdge._secondVertice);
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
                _selectedVertice.ExecuteRelation();
                DrawAllShapes();
            }
        }

        private void radiusTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckIfCircle(_selectedShape))
            {
                var circle = (Circle)_selectedShape;
                circle.SetRadius(int.Parse(radiusTextBox.Text));
                circle.ExecuteRelation();
                DrawAllShapes();
            }
        }

        private void lockCircleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedShape != null && CheckIfCircle(_selectedShape))
            {
                new LockedCircle((Circle)_selectedShape);
            }
        }

        private void LockLengthButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedShape != null && CheckIfCircle(_selectedShape))
            {
                new SpecifiedRadius((Circle)_selectedShape);
            }
            else if (_selectedEdge != null)
            {
                new SpecifiedEdge(_selectedEdge);
            }
        }

        private void equalLengthsButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedEdge != null)
            {
                _selectingSecondEdge = true;
                UnSelectShape();
            }
        }
        private void orthogonalButton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void tangencyButton_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void deleteRelationButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedShape != null)
            {
                _selectedShape.DeleteRelation();
            }
            else if (_selectedVertice != null)
            {
                _selectedVertice.DeleteRelation();
            }
            else if (_selectedEdge != null)
            {
                _selectedEdge.DeleteRelation();
            }
        }
    }
}
