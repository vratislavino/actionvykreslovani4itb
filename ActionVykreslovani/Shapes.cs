using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionVykreslovani
{
    [Serializable]
    public class Shape
    {
        protected Pen outlinePen = new Pen(Color.Black,4) 
        { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        public Color color;
        public Point start;
        public Point end;
        public bool filled;

        public string className;

        public const int size = 400;

        protected string Size {
            get { return "[" + (end.X - start.X) + ":" + (end.Y - start.Y) + "]"; }
        }

        public virtual void Draw(Graphics g) { }

        public virtual void Draw(Graphics g, Point groupPos, Size groupSize) {

        }

        public virtual void Visualize(Graphics g) { }

        public static Shape CreateShape(string shp) {
            //return new Rectangle();
            shp = CorrectType(shp);
            
            Shape s = (Shape) Activator.CreateInstance(
                Type.GetType("ActionVykreslovani." + shp));

            s.className = shp;
            return s;
        }

        public static Shape CreateShape(Shape shp, string newshp) {
            var shape = CreateShape(newshp);
            shape.color = shp.color;
            shape.start = shp.start;
            shape.end = shp.end;
            shape.filled = shp.filled;
            return shape;
        }

        private static string CorrectType(string typ) {
            var types = Enum.GetNames(typeof(ShapeEnum));
            if (types.Contains(typ)) {
                return typ;
            } else {
                return "Rectangle";
            }
        }

        public override string ToString() {
            return GetType().Name + " " + start + " " + Size;
        }
    }

    [Serializable]
    public class Rectangle : Shape
    {
        public override void Draw(Graphics g) {
            this.Draw(g, new Point(0, 0), new Size(size, size));
        }

        public override void Draw(Graphics g, Point groupPos, Size groupSize) {
            float ratioX = (float) groupSize.Width / size;
            float ratioY = (float) groupSize.Height / size;

            if (filled) {
                g.FillRectangle(new SolidBrush(color),
                    start.X * ratioX + groupPos.X,
                    start.Y * ratioY + groupPos.Y,
                    (end.X - start.X) * ratioX,
                    (end.Y - start.Y) * ratioY
                    );

            } else {
                g.DrawRectangle(new Pen(color, 4),
                    start.X * ratioX + groupPos.X,
                    start.Y * ratioY + groupPos.Y,
                    (end.X - start.X) * ratioX,
                    (end.Y - start.Y) * ratioY
                    );
            }
        }

        public override void Visualize(Graphics g) {
            g.DrawRectangle(outlinePen,
                    start.X, start.Y, end.X - start.X, end.Y - start.Y);

        }
    }

    public class Ellipse : Shape
    {
        public override void Draw(Graphics g) {
            this.Draw(g, new Point(0, 0), new Size(size, size));
        }

        public override void Draw(Graphics g, Point groupPos, Size groupSize) {

            float ratioX = (float) groupSize.Width / size;
            float ratioY = (float) groupSize.Height / size;

            if (filled) {
                g.FillEllipse(new SolidBrush(color),
                    start.X * ratioX + groupPos.X,
                    start.Y * ratioY + groupPos.Y,
                    (end.X - start.X) * ratioX,
                    (end.Y - start.Y) * ratioY
                    );

            } else {
                g.DrawEllipse(new Pen(color, 4),
                    start.X * ratioX + groupPos.X,
                    start.Y * ratioY + groupPos.Y,
                    (end.X - start.X) * ratioX,
                    (end.Y - start.Y) * ratioY
                    );
            }
        }

        public override void Visualize(Graphics g) {
            g.DrawEllipse(outlinePen,
                    start.X, start.Y, end.X - start.X, end.Y - start.Y);

        }
    }

    public class Cross : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, 4), start, end);
            g.DrawLine(new Pen(color, 4), start.X, end.Y, end.X, start.Y);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(outlinePen, start, end);
            g.DrawLine(outlinePen, start.X, end.Y, end.X, start.Y);
        }
    }

    public class Line : Shape
    {
        public override void Draw(Graphics g) {
            g.DrawLine(new Pen(color, 4), start, end);
        }

        public override void Visualize(Graphics g) {
            g.DrawLine(outlinePen, start, end);
        }
    }

    public class Triangle : Shape
    {
        public override void Draw(Graphics g) {
            Point[] body = new Point[] {
                new Point(start.X, end.Y),
                end,
                new Point((start.X + end.X)/2, start.Y)
            };
            if (filled) {
                g.FillPolygon(new SolidBrush(color), body);
            } else {
                g.DrawPolygon(new Pen(color, 4), body);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] body = new Point[] {
                new Point(start.X, end.Y),
                end,
                new Point((start.X + end.X)/2, start.Y)
            };
            g.DrawPolygon(outlinePen, body);
        }
    }

    public class Hexagon : Shape
    {
        public override void Draw(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (end.Y+start.Y)/2),
                new Point(start.X + (end.X-start.X)/4, end.Y),
                new Point(start.X + (end.X-start.X)/4*3, end.Y),
                new Point(end.X, (end.Y+start.Y)/2),
                new Point(start.X + (end.X-start.X)/4*3, start.Y),
                new Point(start.X + (end.X-start.X)/4, start.Y)
            };
            if (filled) {
                g.FillPolygon(new SolidBrush(color), points);
            } else {
                g.DrawPolygon(new Pen(color, 4), points);
            }
        }

        public override void Visualize(Graphics g) {
            Point[] points = new Point[] {
                new Point(start.X, (end.Y+start.Y)/2),
                new Point(start.X + (end.X-start.X)/4, end.Y),
                new Point(start.X + (end.X-start.X)/4*3, end.Y),
                new Point(end.X, (end.Y+start.Y)/2),
                new Point(start.X + (end.X-start.X)/4*3, start.Y),
                new Point(start.X + (end.X-start.X)/4, start.Y)
            };
            g.DrawPolygon(outlinePen, points);

        }
    }

    public enum ShapeEnum
    {
        Rectangle,
        Cross,
        Ellipse,
        Triangle,
        Line,
        Hexagon
    }
}
