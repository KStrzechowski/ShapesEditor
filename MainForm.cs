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
using ShapesEditor.Drawing;

namespace ShapesEditor
{
    public partial class MainForm : Form
    {
        private readonly List<IShape> _shapes = new();
        private IShape _newShape;
        private Point _position;
        private List<Point> _vertices = new();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainPictureBox.Image = new Bitmap(mainPictureBox.Width, mainPictureBox.Height);
            DrawShape._bitmap = (Bitmap)mainPictureBox.Image;
        }

        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var myList = new List<Point>();
            if (mainListBox.SelectedIndex == 0)
            {

            }

            
            myList.Add(new Point(10, 10));
            myList.Add(new Point(40, 50));
            myList.Add(new Point(20, 10));
            myList.Add(new Point(100, 80));
            Polygon polygon = new Polygon(myList);
            polygon.Draw();
        }

        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _position = new Point(e.X, e.Y);
            _newShape.UpdateShape(_position);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_newShape != null)
            {
                _newShape.Draw();
            }
            _newShape = null;
        }

        private void mainListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainListBox.SelectedIndex == 0)
            {

            }
            else if (mainListBox.SelectedIndex == 1)
            {

            }
        }
    }
}
