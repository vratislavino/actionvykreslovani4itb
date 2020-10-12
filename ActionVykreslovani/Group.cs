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

        
        int arrowSize = 10;
        private static Pen arrowPen = new Pen(Color.Blue, 3);


        public bool Selected { get; set; }

        public Group() { }

        public Group(Group origin) {
            this.name = origin.name;
            position = new Point(0, 0);
            size = new Size(400, 400);
            shapes = origin.shapes;
        }

        public bool ContainsPoint(Point point) {
            return point.X > position.X - arrowSize && point.X < position.X + size.Width + arrowSize &&
                point.Y > position.Y - arrowSize && point.Y < position.Y + size.Height + arrowSize;
        }

        public void Draw(Graphics g) {
            shapes.ForEach(x => x.Draw(g, position, size));
            if(Selected) {
                g.DrawRectangle(Pens.Red, position.X, position.Y, size.Width, size.Height);
                DrawArrows(g);
            }
        }

        private void DrawArrows(Graphics g) {
            g.DrawLine(arrowPen, position.X - arrowSize, position.Y, position.X + arrowSize, position.Y);
            g.DrawLine(arrowPen, position.X, position.Y - arrowSize, position.X, position.Y + arrowSize);

            g.DrawLine(arrowPen, 
                position.X + size.Width, 
                position.Y + size.Height, 
                position.X + size.Width + arrowSize, 
                position.Y + size.Height);
            g.DrawLine(arrowPen,
                position.X + size.Width,
                position.Y + size.Height,
                position.X + size.Width,
                position.Y + size.Height + arrowSize);
        }

        public Operation GetAction(Point mouse) {
            var topleft = position;
            var botright = new Point(position.X + size.Width, position.Y + size.Height);
            
            if(mouse.Distance(topleft) < arrowSize) {
                return Operation.Move;
            }

            if(mouse.Distance(botright) < arrowSize) {
                return Operation.Resize;
            }

            return Operation.None;
        }

        public void Move(Point mouse) {
            position = mouse;
        }

        public void Resize(Point mouse) {
            size = new Size(Math.Max(0,mouse.X - position.X), Math.Max(0, mouse.Y - position.Y));
        }
    }
}
