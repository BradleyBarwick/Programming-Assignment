using System.Drawing;

namespace Programming_Assignment
{
    public class Draw : Canvas
    {
        protected bool Fill;
        /// <summary>
        /// function to draw a rectangle in relation to x and y position of the pen using width and height integers.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void DrawRectangle(int width, int height)
        {
            Shape rect = new ShapeFactory().getShape("rectangle");
            rect.set(Pen.Color, xPos, yPos, Pen.Width, width, height);
            if (!this.FillShapes())
            {
                rect.draw(g);
            }
            else
            {
                rect.isFilled(true);
                rect.draw(g);
            }

        }
        /// <summary>
        /// function to draw a circle in relation to the x and y position of the pen using the radius inputed.
        /// </summary>
        /// <param name="radius"></param>
        public void DrawCircle(int radius)
        {
            Shape circle = new ShapeFactory().getShape("circle");
            circle.set(Pen.Color, xPos, yPos, Pen.Width, radius);
            if (!this.FillShapes())
            {
                circle.draw(g);
            }
            else
            {
                circle.isFilled(true);
                circle.draw(g);
            }
    }
        /// <summary>
        /// function to draw a triangle in relation to x and y position of the pen and takes in 3 integers to create the polygon shape.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void DrawTriangle(float x, float y, float z)
        {
            PointF point1 = new PointF(x, y);
            PointF point2 = new PointF(y, z);
            PointF point3 = new PointF(z, x);
            PointF[] curvePoints = { point1, point2, point3 };
            g.DrawPolygon(Pen, curvePoints);
        }
        /// <summary>
        /// function to move the pen to a specific location via inputed values if x and y.
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void moveTo(int toX, int toY)
        {
            base.xPos = toX;
            base.yPos = toY;
        }
        /// <summary>
        /// function to change the colour of the pen via specified colour.
        /// </summary>
        /// <param name="colour"></param>
        public void SetPenColour(string colour)
        {
            DrawColour = Color.FromName(colour);
            base.Pen = new Pen(DrawColour, 1);
            base.SolidBrush = new SolidBrush(DrawColour);
        }
        /// <summary>
        /// function to turn on fill when the shape is drawn.
        /// </summary>
        public void FillToTrue()
        {
            Fill = true;
        }
        /// <summary>
        /// function to turn off fill when the shape is drawn.
        /// </summary>
        public void FillToFalse()
        {
            Fill = false;
        }
        public bool FillShapes()
        {
            return Fill;
        }
        /// <summary>
        /// function to draw a line from the pens current x and y to a new specified x and y
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        public void drawTo(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
        }

        public Draw(Graphics g) : base(g)
        {
            Fill = false;
        }
    }
}
