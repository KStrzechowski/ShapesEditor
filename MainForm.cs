using ShapesEditor.Data;
using ShapesEditor.Enums;
using ShapesEditor.Relations;
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
    public partial class MainForm : Form
    {
        private readonly List<IShape> _shapes = new();
        private Point _position;
        private State _currentState; 
        private State _stateForRelations;
        private SelectedItems _items;
        private RelationId _newRelation; 

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetAllDefault();
            HideAllOptions();
            CreateRandomFigures();
        }

        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _position = new Point(e.X, e.Y);
            ChangePositionTextBoxes(_position);

            switch (_currentState)
            {
                case State.Default:
                    {
                        SelectShape(_position);
                        break;
                    }
                case State.NewShape:
                    {
                        var vertice = new Vertice(_position);
                        _items.shape.UpdateShape(vertice);
                        break;
                    }
                case State.SelectedShape:
                    {
                        if (CheckIfVertice(out Vertice clickedVertice))
                        {
                            SelectVertice(clickedVertice);
                        }

                        if (_items.vertice == null && CheckIfShape())
                        {
                            SetState(State.MoveShape);
                        }
                        break;
                    }
                case State.SelectedVertice:
                    {
                        if (CheckIfEdge(out Vertice clickedVertice))
                        {
                            SelectEdge(new Edge(_items.vertice, clickedVertice, (Polygon)_items.shape));
                        }
                        break;
                    }
                case State.SelectedEdge:
                    {
                        if (_items.edge.CheckIfClicked(_position))
                        {
                            SetState(State.MoveEdge);
                        }
                        else
                        {
                            UnSelectEdge();
                            if (!_items.shape.CheckIfClicked(_position))
                                UnSelectShape();
                        }
                        break;
                    }
                case State.SelectingCircle:
                    {
                        SelectShape(_position);
                        if (_items.shape != null && CheckIfCircle(_items.shape))
                        {
                            new Tangency((Circle)_items.shape, _items.secondEdge);
                            SetAllDefault();
                        }
                        break;
                    }
                case State.SelectingSecondEdge:
                    {
                        switch (_stateForRelations)
                        {
                            case State.Default:
                                {
                                    SelectShape(_position);
                                    if (_items.shape != null && CheckIfPolygon(_items.shape))
                                    {
                                        _stateForRelations = State.SelectedShape;
                                    }
                                    else
                                    {
                                        UnSelectShape();
                                    }
                                    break;
                                }
                            case State.SelectedShape:
                                {

                                    if (CheckIfVertice(out Vertice clickedVertice))
                                    {
                                        SelectVertice(clickedVertice);
                                        _stateForRelations = State.SelectedVertice;
                                    }
                                    break;
                                }
                            case State.SelectedVertice:
                                {
                                    if (CheckIfEdge(out Vertice clickedVertice))
                                    { 
                                        _items.edge = new Edge(_items.vertice, clickedVertice, (Polygon)_items.shape);
                                        _items.edge.Select();
                                        if (_items.edge.Equals(_items.secondEdge))
                                        {
                                            UnSelectShape();
                                            break;
                                        }

                                        switch (_newRelation)
                                        {
                                            case RelationId.EqualEdges:
                                                {
                                                    new EqualEdges(_items.edge, _items.secondEdge);
                                                    break;
                                                }
                                            case RelationId.OrthogonalLines:
                                                {
                                                    new OrthogonalLines(_items.edge, _items.secondEdge);
                                                    break;
                                                }
                                            case RelationId.Tangency:
                                                {
                                                    new Tangency((Circle)_items.secondShape, _items.edge);
                                                    break;
                                                }
                                        }

                                        SetAllDefault();
                                    }
                                    break;
                                }
                        }
                    }
                    break;
            }
            SetOptionsForCorrectShape();
            DrawAllShapes();
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            var position = new Point(e.X, e.Y);

            switch (_currentState)
            {
                case State.MoveShape:
                    {
                        MoveShape(position);
                        break;
                    }
                case State.MoveVertice:
                    {
                        MoveVertice(position);
                        break;
                    }
                case State.MoveEdge:
                    {
                        MoveEdge(position);
                        break;
                    }
            }
            _position = position;
        }

        private void mainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.MoveShape:
                    {
                        _items.shape.ExecuteRelation();
                        SetState(State.SelectedShape);
                        break;
                    }
                case State.MoveVertice:
                    {
                        SetState(State.SelectedVertice);
                        break;
                    }
                case State.MoveEdge:
                    {
                        SetState(State.SelectedEdge);
                        break;
                    }
            }
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UnSelectShape();
            SetState();
            if (mainListBox.SelectedIndex == 0)
            {
                _items.shape = new Polygon();
                SetState(State.NewShape);
            }
            else if (mainListBox.SelectedIndex == 1)
            {
                _items.vertice = new Vertice(new Point(100, 100));
                _items.shape = new Circle(_items.vertice, 50);
                SetState(State.NewShape);
            }

            if (_currentState == State.NewShape)
            {
                _items.shape.Select();
                SetOptionsForCorrectShape();
            }
        }

        private void addButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.NewShape:
                    {
                        if (_items.shape.CheckIfCorrect())
                        {
                            _shapes.Add(_items.shape);
                            DrawAllShapes();
                        }
                        break;
                    }
                case State.SelectedEdge:
                    {
                        _items.edge.DeleteRelation();
                        var polygon = (Polygon)_items.shape;
                        polygon.AddVertice(_items.edge._firstVertice, _items.edge._secondVertice);
                        break;
                    }
            }
            SetState();
            UnSelectShape();
        }

        private void deleteButton_MouseClick(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.SelectedShape:
                    {
                        _shapes.Remove(_items.shape);
                        break;
                    }
                case State.SelectedVertice:
                    {
                        var polygon = (Polygon)_items.shape;
                        polygon.Remove(_items.vertice);
                        if (!_items.shape.CheckIfCorrect())
                            _shapes.Remove(_items.shape);
                        break;
                    }
            }
            SetState();
            UnSelectShape();
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

                switch (_currentState)
                {
                    case State.NewShape:
                    case State.SelectedShape:
                        {
                            if (CheckIfCircle(_items.shape))
                            {
                                var circle = (Circle)_items.shape;
                                circle.SetCenterPosition(_position);
                                circle.ExecuteRelation();
                            }
                            break;
                        }
                    case State.SelectedVertice:
                        {
                            _items.vertice.SetPosition(_position);
                            break;
                        }
                }
                DrawAllShapes();
            }
        }

        private void radiusTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && _currentState == State.SelectedShape && CheckIfCircle(_items.shape))
            {
                switch (_currentState)
                {
                    case State.NewShape:
                    case State.SelectedShape:
                        {
                            if (CheckIfCircle(_items.shape))
                            {
                                var circle = (Circle)_items.shape;
                                circle.SetRadius(int.Parse(radiusTextBox.Text));
                                circle.ExecuteRelation();
                            }
                            break;
                        }
                }
                if (!_items.shape.CheckIfCorrect())
                {
                    _shapes.Remove(_items.shape);
                }
                DrawAllShapes();
            }
        }

        private void lockCircleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentState == State.SelectedShape && CheckIfCircle(_items.shape))
            {
                new LockedCircle((Circle)_items.shape);
            }
        }

        private void LockLengthButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentState == State.SelectedShape && CheckIfCircle(_items.shape))
            {
                new SpecifiedRadius((Circle)_items.shape);
            }
            else if (_currentState == State.SelectedEdge)
            {
                new SpecifiedEdge(_items.edge);
            }
        }

        private void equalLengthsButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentState == State.SelectedEdge)
            {
                _items.secondEdge = _items.edge;
                SetState(State.SelectingSecondEdge);
                SetRelation(RelationId.EqualEdges);
                UnSelectShape();
            }
        }
        private void orthogonalButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (_currentState == State.SelectedEdge)
            {
                _items.secondEdge = _items.edge;
                SetState(State.SelectingSecondEdge);
                SetRelation(RelationId.OrthogonalLines);
                UnSelectShape();
            }
        }

        private void tangencyButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            { 
                case State.SelectedShape:
                    {
                        if (CheckIfCircle(_items.shape))
                        {
                            _items.secondShape = _items.shape;
                            SetState(State.SelectingSecondEdge);
                            UnSelectShape();
                        }
                        SetRelation(RelationId.Tangency);
                        break;
                    }
                case State.SelectedEdge:
                    {
                        _items.secondEdge = _items.edge;
                        SetState(State.SelectingCircle);
                        SetRelation(RelationId.Tangency);
                        UnSelectShape();
                        break;
                    }
            }
        }

        private void deleteRelationButton_MouseDown(object sender, MouseEventArgs e)
        {
            switch (_currentState)
            {
                case State.SelectedShape:
                    {
                        _items.shape.DeleteRelation();
                        break;
                    }
                case State.SelectedVertice:
                    {
                        _items.vertice.DeleteRelation();
                        break;
                    }
                case State.SelectedEdge:
                    {
                        _items.edge.DeleteRelation();
                        break;
                    }
            }
            SetState();
            UnSelectShape();
        }
    }
}
