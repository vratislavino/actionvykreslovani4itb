using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionVykreslovani
{
    public class Group
    {
        public List<Shape> shapes;
        public string name;

        public Point position = new Point(0,0);
        public Size size = new Size(400, 400);

        public bool Selected { get; set; }

        public Group() { }

        public Group(Group origin) {
            this.name = origin.name;
            position = new Point(0, 0);
            size = new Size(400, 400);
            shapes = origin.shapes;
        }

        public bool ContainsPoint(Point point) {
            return point.X > position.X && point.X < position.X + size.Width &&
                point.Y > position.Y && point.Y < position.Y + size.Height;
        }

        public void Draw(Graphics g) {
            shapes.ForEach(x => x.Draw(g, position, size));
            if(Selected) {
                g.DrawRectangle(Pens.Red, position.X, position.Y, size.Width, size.Height);
            }
        }
    }
}
