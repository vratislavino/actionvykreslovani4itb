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
    public partial class Form1 : Form
    {
        List<Group> groups = new List<Group>();

        List<Group> drawnGroups = new List<Group>();
        Group selectedGroup = null;
        private Operation operation = Operation.None;

        public Form1() {
            InitializeComponent();
            // comment me :)
        }

        private void AddButton_Click(object sender, EventArgs e) {
            GroupManager gm = new GroupManager();
            gm.FormClosing += OnGroupManagerClosing;

            gm.ShowDialog();
        }

        private void OnGroupManagerClosing(object sender, FormClosingEventArgs e) {
            string name = ((GroupManager) sender).GroupName;
            var shapes = ((GroupManager) sender).Shapes;

            if (!string.IsNullOrEmpty(name) && shapes.Count > 0) {
                Group g = new Group() { shapes = shapes, name = name };
                groups.Add(g);
                UpdateGroups();
            }
        }

        private void UpdateGroups() {
            flowLayoutPanel1.Controls.Clear();
            foreach (var group in groups) {
                GroupView gv = new GroupView();
                gv.SetGroup(group);
                gv.GroupClicked += GroupClicked;
                flowLayoutPanel1.Controls.Add(gv);
            }
        }

        private void GroupClicked(GroupView obj) {
            Group g = new Group(obj.Group);
            drawnGroups.Add(g);
            g.size = new Size(200, 200);
            g.position = new Point(canvas1.Width / 2 - g.size.Width/2, canvas1.Height / 2 - g.size.Height/2);
            
            canvas1.Refresh();
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e) {
            Group tempSelected = null;

            foreach (Group g in drawnGroups) {
                if (g.ContainsPoint(e.Location)) {
                    tempSelected = g;
                    break;
                }
            }

            if(tempSelected != null) {
                if (selectedGroup != null)
                    selectedGroup.Selected = false;
                selectedGroup = tempSelected;
                selectedGroup.Selected = true;
            } else {
                if (selectedGroup != null)
                    selectedGroup.Selected = false;
            }

            if(selectedGroup != null && operation != Operation.None) {
                if (operation == Operation.Move)
                    selectedGroup.Move(e.Location);
                if (operation == Operation.Resize)
                    selectedGroup.Resize(e.Location);
            }

            canvas1.Refresh();
        }

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            drawnGroups.ForEach(x => x.Draw(e.Graphics));
        }

        private void canvas1_MouseDown(object sender, MouseEventArgs e) {
            if(selectedGroup != null) {
                operation = selectedGroup.GetAction(e.Location);
            }
        }

        private void canvas1_MouseUp(object sender, MouseEventArgs e) {
            operation = Operation.None;
        }
    }

    public enum Operation
    {
        None, Move, Resize
    }
}
