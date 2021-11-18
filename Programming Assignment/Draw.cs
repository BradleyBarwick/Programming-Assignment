using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Programming_Assignment
{
    class Draw : Canvas
    {
        protected bool Fill;

        public void DrawRectangle(int width, int height)
        {
            if (!Fill)
            {
                g.DrawRectangle(Pen, xPos, yPos, xPos + width, yPos + height);
            }
            else
            {
                g.FillRectangle(SolidBrush, xPos, yPos, xPos + width, yPos + height);
            }

        }
        public void DrawCircle(int radius)
        {
            if (!Fill)
            {
                g.DrawEllipse(Pen, xPos, yPos, radius, radius);
            }
            else
            {
                g.FillEllipse(SolidBrush, xPos, yPos, radius, radius);
            }
        }

        public void DrawTriangle()
        {
            
        }

        public void moveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }

        public void SetPenColour(string colour)
        {
            DrawColour = Color.FromName(colour);
        }

        public void FillToTrue()
        {
            Fill = true;
        }

        public void FillToFalse()
        {
            Fill = false;
        }

        public void drawTo(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void reset()
        {

        }

        public void clear()
        {
           
        }


        public Draw(Graphics g) : base(g)
        {
            Fill = false;
        }
    }
}
