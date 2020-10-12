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
    public partial class GroupView : UserControl
    {
        public event Action<GroupView> GroupClicked;
        private Group group;
        public Group Group => group;

        public GroupView() {
            InitializeComponent();
            command1.SetDraggable(false);
            command2.SetDraggable(false);
            command3.SetDraggable(false);
        }

        public void SetGroup(Group g) {
            group = g;
            label1.Text = g.name;

            if (g.shapes.Count > 0)
                command1.Shape = g.shapes[0];
            else
                command1.Visible = false;

            if (g.shapes.Count > 1)
                command2.Shape = g.shapes[1];
            else
                command2.Visible = false;

            if (g.shapes.Count > 2)
                command3.Shape = g.shapes[2];
            else
                command3.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
            GroupClicked?.Invoke(this);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e) {
            if(group.shapes != null && group.shapes.Count > 0) {
                group.shapes.ForEach(x => x.Draw(e.Graphics, new Point(0, 0), 
                    new Size(pictureBox1.Width, pictureBox1.Height)));
            }
        }
    }
}
