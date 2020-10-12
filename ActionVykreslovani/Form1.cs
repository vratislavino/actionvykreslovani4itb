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

        public Form1() {
            InitializeComponent();
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
            g.position = new Point(200, 0);
            g.size = new Size(100, 100);
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

            /*
            if (selectedGroup != null) {
                if (tempSelected != selectedGroup) {
                    selectedGroup.Selected = false;
                    if (tempSelected != null) {
                        selectedGroup = tempSelected;
                        selectedGroup.Selected = true;
                    }
                }
            } else {
                if (tempSelected != null) {
                    selectedGroup = tempSelected;
                    selectedGroup.Selected = true;
                }
            }*/

            canvas1.Refresh();
        }

        private void canvas1_Paint(object sender, PaintEventArgs e) {
            drawnGroups.ForEach(x => x.Draw(e.Graphics));
        }
    }
}
