using ShapesEditor.Data;
using ShapesEditor.Enums;
using ShapesEditor.Structures;
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
    public partial class MainForm
    {
        private void CreateRandomFigures()
        {
            _shapes.Add(CreateRandomCircle());
            _shapes.Add(CreateRandomCircle());
            _shapes.Add(CreateRandomPolygon());
            _shapes.Add(CreateRandomPolygon());
            DrawAllShapes();
        }
        private Polygon CreateRandomPolygon()
        {
            Random rand = new Random();
            Polygon polygon = new Polygon();
            int n = rand.Next(3, 7);
            for (int i = 0; i < n; i++)
            {
                polygon.UpdateShape(new Vertice(new Point(rand.Next(mainPictureBox.Width), rand.Next(mainPictureBox.Height))));
            }
            return polygon;
        }
        private Circle CreateRandomCircle()
        {
            Random rand = new Random();
            Circle circle = new Circle(new Vertice(new Point(rand.Next(mainPictureBox.Width), rand.Next(mainPictureBox.Height))), rand.Next(30, 300));
            return circle;
        }

        private void SetBitmap()
        {
            mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            BaseShape._bitmap = (Bitmap)mainPictureBox.Image;
            BaseShape._graphics = Graphics.FromImage(mainPictureBox.Image);
        }

        private void SetState() => _currentState = State.Default;
        private void SetState(State state) => _currentState = state;
        private void SetRelation() => _newRelation = RelationId.Default;
        private void SetRelation(RelationId relationId) => _newRelation = relationId;

        private void SetAllDefault()
        {
            SetState();
            SetRelation();
            _stateForRelations = State.Default;
            _position = new Point(0, 0);
            _items = _items.UnSelect();
        }

        private void DrawAllShapes()
        {
            SetBitmap();
            if (_currentState == State.NewShape)
                _items.shape.Draw();
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
                    _items.shape = shape;

                    if (_newRelation == RelationId.Default)
                    {
                        SetState(State.MoveShape);
                    }
                    break;
                }
            }
        }

        private void SelectVertice(Vertice vertice)
        {
            vertice.Select();
            _items.vertice = vertice;
            if (_newRelation == RelationId.Default)
            {
                SetState(State.MoveVertice);
            }
        }

        private void SelectEdge(Edge edge)
        {
            edge.Select();
            _items.edge = edge;
            if (_newRelation == RelationId.Default)
            {
                SetState(State.SelectedEdge);
            }
        }

        private void MoveShape(Point position)
        {
            _items.shape.Move(_position, position);
            if (CheckIfCircle(_items.shape))
            {
                Circle circle = (Circle)_items.shape;
                ChangePositionTextBoxes(circle.GetCenterPostion());
            }
            _items.shape.ExecuteRelation();
            DrawAllShapes();
        }

        private void MoveVertice(Point position)
        {
            _items.vertice.Move(_position, position);
            DrawAllShapes();
            ChangePositionTextBoxes(_items.vertice.GetPosition());
        }

        private void MoveEdge(Point position)
        {
            _items.edge.Move(_position, position);
            DrawAllShapes();
        }

        private void UnSelectShape()
        {
            if (_items.shape != null)
            {
                UnSelectVertice();
                _items.shape.UnSelect();
                _items.shape = null;

                mainListBox.SelectedIndex = -1;
                HideAllOptions();

                if (_newRelation == RelationId.Default)
                {
                    SetState(State.Default);
                }
            }
            DrawAllShapes();
        }

        private void UnSelectVertice()
        {
            if (_items.vertice != null)
            {
                UnSelectEdge();
                _items.vertice.UnSelect();
                _items.vertice = null;

                if (_newRelation == RelationId.Default)
                {
                    SetState(State.SelectedShape);
                }
            }
        }

        private void UnSelectEdge()
        {
            if (_items.edge != null)
            {
                _items.edge.UnSelect();
                _items.edge = null;

                if (_newRelation == RelationId.Default)
                {
                    SetState(State.SelectedShape);
                }
            }
        }

        private void SetOptionsForCorrectShape()
        {
            HideAllOptions();
            switch (_currentState)
            {
                case State.NewShape:
                    {
                        SelectedNewShape();
                        break;
                    }
                case State.SelectedShape:
                case State.MoveShape:
                    {
                        if (CheckIfCircle(_items.shape))
                            SelectedCircle();
                        else
                            SelectedPolygon();
                        break;
                    }
                case State.SelectedVertice:
                case State.MoveVertice:
                    {
                        SelectedVertice();
                        break;
                    }
                case State.SelectedEdge:
                case State.MoveEdge:
                    {
                        SelectedEdge();
                        break;
                    }
            }
        }

        private void SelectedNewShape()
        {
            addButton.Enabled = true;
            if (CheckIfCircle(_items.shape))
            {
                SelectedCircle();
            }
            else
            {
                SelectedPolygon();
            }
        }

        private void SelectedCircle()
        {
            deleteButton.Enabled = deleteRelationButton.Enabled = true;
            radiusLabel.Enabled = radiusTextBox.Enabled = true;
            positionXTextBox.Enabled = positionYTextBox.Enabled = positionLabel.Enabled = true;
            lockCircleButton.Enabled = LockLengthButton.Enabled = true;
        }

        private void SelectedPolygon()
        {
            deleteButton.Enabled = deleteRelationButton.Enabled  = true;
        }

        private void SelectedVertice()
        {
            deleteButton.Enabled = true;
            positionXTextBox.Enabled = positionYTextBox.Enabled = positionLabel.Enabled = true;
        }

        private void SelectedEdge()
        {
            addButton.Enabled = deleteRelationButton.Enabled = true;
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

        private bool CheckIfShape()
        {
            if (_items.shape != null && _items.shape.CheckIfClicked(_position))
            {
                return true;
            }
            else
            {
                UnSelectShape();
            }
            return false;
        }

        private bool CheckIfVertice(out Vertice vertice)
        {
            vertice = null;
            if (_items.shape != null && CheckIfPolygon(_items.shape))
            {
                Polygon polygon = (Polygon)_items.shape;
                if (polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
                {
                    vertice = clickedVertice;
                    return true;
                }
            }
            CheckIfShape();
            return false;
        }

        private bool CheckIfEdge(out Vertice vertice)
        {
            vertice = null;
            Polygon polygon = (Polygon)_items.shape;
            if (_items.vertice != null && polygon.CheckIfClickedVertice(_position, out Vertice clickedVertice))
            {
                if (polygon.CheckIfEdge(_items.vertice, clickedVertice))
                {
                    vertice = clickedVertice;
                    return true;
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
                if (!_items.shape.CheckIfClicked(_position))
                    UnSelectShape();
            }
            return false;
        }
    }
}
