using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionVykreslovani
{
    // http://oddtgames.cz/tests/ActionVykreslovani.rar

    public partial class CommandForm : Form
    {
        Color color = Color.Black;
        private bool mouseDown = false;
        Shape shape;

        public Shape Shape => shape;

        private List<Shape> dummyShapes;

        public CommandForm() {
            InitializeComponent();
        }

        public void VisualizeShapes(List<Shape> shapes) {
            dummyShapes = shapes;
            Refresh();
        }

        private void ColorButton_Click(object sender, EventArgs e) {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                this.color = colorDialog1.Color;
                colorButton.BackColor = colorDialog1.Color;
            }
        }

        private void CommandForm_Load(object sender, EventArgs e) {
            var nazvy = Enum.GetNames(typeof(ShapeEnum));
            comboBox1.Items.AddRange(nazvy);

        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e) {
            shape = Shape.CreateShape(comboBox1.Text);
            shape.color = color;
            shape.filled = checkBox1.Checked;
            shape.start = e.Location;
            shape.end = e.Location;
            panel1.Refresh();
            mouseDown = true;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e) {
            if (!mouseDown)
                return;

            if(shape != null) {
                shape.end = e.Location;
                Refresh();
            } 
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e) {
            mouseDown = false;
        }

        private void Panel1_Paint(object sender, PaintEventArgs e) {
            if (dummyShapes != null)
                dummyShapes.ForEach(x => x.Visualize(e.Graphics));
            if (shape != null) 
                shape.Draw(e.Graphics);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) {
            if (shape != null) {
                shape.filled = ((CheckBox) sender).Checked;
                panel1.Refresh();
            }
        }

        private void ColorButton_BackColorChanged(object sender, EventArgs e) {
            if (shape != null) {
                shape.color = color;
                panel1.Refresh();
            }
        }

        private void ComboBox1_TextChanged(object sender, EventArgs e) {
            if(shape != null) {
                shape = Shape.CreateShape(shape, comboBox1.Text);
                Refresh();
            }
        }

        private void Button1_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
