﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Programming_Assignment
{
    class Canvas
    {
        protected Graphics g;
        protected Pen Pen;
        protected SolidBrush SolidBrush;
        protected Color DrawColour;
        protected int xPos, yPos; //Position of the pen when drawing

        public Canvas(Graphics g)
        {
            this.g = g;
            xPos = 0;
            yPos = 0;
            DrawColour = Color.Black;
            Pen = new Pen(DrawColour, 1);
            SolidBrush = new SolidBrush(DrawColour);
        }

        public Graphics GetGraphics()
        {
            return this.g;
        }

    }
}
