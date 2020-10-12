using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActionVykreslovani
{
    public partial class Command : UserControl
    {
        public event Action<Command> OnDragStart;
        public event Action<Command> OnDragEnd;
        public event Action<Command> OnControlMoved;

        public event Action<Command> OnDelete;
        string text;

        Font myFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (238)));

        private Shape shape;
        public Shape Shape {
            get { return shape; }
            set {
                shape = value;
                if (shape != null) {
                    colorPctbx.BackColor = shape.color;
                    text = shape.ToString();
                }
            }
        }

        public Command() {
            InitializeComponent();
        }

        public void SetDraggable(bool draggable) {
            ControlExtension.Draggable(this, draggable);
        }

        private void Command_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawString(text, myFont, Brushes.Black, 45, 6);
        }

        private void Command_DoubleClick(object sender, EventArgs e) {
            OnDelete?.Invoke(this);
        }

        private void Command_MouseDown(object sender, MouseEventArgs e) {
            OnDragStart?.Invoke(this);
        }

        private void Command_MouseUp(object sender, MouseEventArgs e) {
            OnDragEnd?.Invoke(this);
        }

        private void Command_Move(object sender, EventArgs e) {
            OnControlMoved?.Invoke(this);
        }
    }
}
