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
    public partial class GroupManager : Form
    {
        List<Shape> shapes;
        List<Command> commands;
        Command draggedCommand = null;

        public List<Shape> Shapes => shapes;
        public string GroupName => textBox1.Text;

        public GroupManager() {
            InitializeComponent();
            shapes = new List<Shape>();
            commands = new List<Command>();
        }

        private void UpdateCommands() {
            panel2.Controls.Clear();
            commands.Clear();
            for (int i = 0; i < shapes.Count; i++) {
                Shape shp = shapes[i];
                Command c = new Command();
                c.SetDraggable(true);
                c.Shape = shp;
                c.OnDelete += OnCommandDelete;
                c.Location = new Point(0,i*c.Height);
                c.OnDragStart += CommandOnDragStart;
                c.OnDragEnd += CommandOnDragEnd;
                c.OnControlMoved += CommandOnControlMoved;
                commands.Add(c);
                panel2.Controls.Add(c);
            }
        }
        private void CommandOnControlMoved(Command obj) {
            ReorganizeCommands();
        }

        private void ReorganizeCommands() {
            commands = commands.OrderBy(x => x.Location.Y).ToList();
            for (int i = 0; i < commands.Count; i++) {
                if (commands[i] == draggedCommand)
                    continue;
                commands[i].Location = new Point(0, i*commands[i].Height);
            }
        }

        private void CommandOnDragEnd(Command obj) {
            draggedCommand = null;
            ReorganizeCommands();
            shapes = commands.Select(x => x.Shape).ToList();
            panel1.Refresh();
        }

        private void CommandOnDragStart(Command obj) {
            draggedCommand = obj;
        }

        private void OnCommandDelete(Command com) {
            shapes.Remove(com.Shape);
            panel2.Controls.Remove(com);
            commands.Remove(com);
            ReorganizeCommands();
            panel1.Refresh();
        }

        private void AddButton_Click(object sender, EventArgs e) {
            CommandForm cf = new CommandForm();
            cf.VisualizeShapes(shapes);
            cf.FormClosing += OnCommandFormClosing;
            cf.ShowDialog();

        }

        private void OnCommandFormClosing(object sender, FormClosingEventArgs e) {
            var shape = ((CommandForm) sender).Shape;
            if (shape == null)
                return;

            shapes.Add(shape);
            UpdateCommands();
            panel1.Refresh();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e) {
            foreach(var shape in shapes) {
                shape.Draw(e.Graphics);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            if(shapes.Count == 0) {
                var res = MessageBox.Show("Prázdná group se neuloží! Chcete pokračovat?",
                    "Pozor!",
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);
                if(res == DialogResult.Yes) {
                    this.Close();
                    return;
                } else {
                    return;
                }
            }
            if (string.IsNullOrEmpty(textBox1.Text)) {
                var res = MessageBox.Show("Group bez nászvu se neuloží! Chcete pokračovat?",
                    "Pozor!",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (res == DialogResult.Yes) {
                    this.Close();
                    return;
                } else {
                    return;
                }
            }

            this.Close();
        }

        public GroupData CreateData() {
            return new GroupData() {
                name = textBox1.Text,
                shapes = shapes
            };
        }
    }
}
