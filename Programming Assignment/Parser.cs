using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Programming_Assignment
{
    class Parser
    {

        protected Graphics GraphicsContext;
        protected Draw Draw;

        public Parser(Graphics g)
        {
            GraphicsContext = g;
            Draw = new Draw(GraphicsContext);
        }

        public void ParseCommand(string input)
        {
            string cmd = input.Trim().ToLower();
            string[] split = cmd.Split(" ");

            string[] splitparam = null;

            if (split.Length == 2)
            {
                splitparam = split[1].Split(",");
            }
            else
            {
                if (split.Length > 2)
                {
                    //too many parameters inputed - add to error list
                }

                else
                {
                    if (split.Length <= 1)
                    {
                        // no parameters inputted - add to error list
                    }
                }
            }

            switch (split[0])
            {
                case "circle":
                    if (splitparam.Length > 1)
                    {
                        
                    }

                    if (splitparam.Length != 1)
                    {
                        // no parameter inputted
                    }
                    Draw.DrawCircle(Int32.Parse(splitparam[0]));
                    break;

                case "rect":
                    if (splitparam.Length > 2)
                    {
                        // To many parameters
                    }
                    if (splitparam.Length != 2)
                    {
                        // missing parameters
                    }
                    Draw.DrawRectangle(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "triangle":
                    if (splitparam.Length > 3)
                    {
                        // too many parameters
                    }
                    if (splitparam.Length != 3 && splitparam.Length != 1)
                    {
                        // missing parameters
                    }
                    //Draw.DrawTriangle(Int32.Parse(splitparam[0]), (Int32.Parse(splitparam[1]), (Int32.Parse(splitparam[2]))));
                    break;

                case "moveTo":
                    if (splitparam.Length > 2)
                    {
                        // too many parameters
                    }
                    if (splitparam.Length < 2)
                    {
                        // missing parameters
                    }
                    Draw.moveTo(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "pen":
                    if (splitparam.Length > 1)
                    {
                        // too many parameters
                    }
                    switch (splitparam[0])
                    {
                        case "black":
                            Draw.SetPenColour("black");
                            break;
                        case "blue":
                            Draw.SetPenColour("blue");
                            break;
                        case "green":
                            Draw.SetPenColour("green");
                            break;
                        case "red":
                            Draw.SetPenColour("red");
                            break;
                        case "yellow":
                            Draw.SetPenColour("yellow");
                            break;
                        default:
                            //unknown colour
                            break;
                    }
                    break;

                case "fill":
                    if (splitparam[0].Equals("1"))
                    {
                        Draw.FillToTrue();
                    }
                    else
                    {
                        Draw.FillToFalse();
                    }
                    break;

                case "drawto":
                    if (splitparam.Length > 2)
                    {
                        // too many parameters
                    }    
                    if (splitparam.Length != 2)
                    {
                        // missing parameters
                    }
                    Draw.drawTo(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "reset":
                    Draw.moveTo(0, 0);
                    break;

                case "clear":
                    
                    break;

                default:
                    break;
            }





        }
    }
}
