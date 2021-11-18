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
        private float TextYFloatOffset = 10.0f;

        public Parser(Graphics g)
        {
            GraphicsContext = g;
            Draw = new Draw(GraphicsContext);
        }

        private void PopulateErrors(string[] errors)
        {
            Font Font = new Font(new FontFamily("Arial"), 15);
            foreach (string error in errors)
            {
                GraphicsContext.DrawString(error, Font, new SolidBrush(Color.Black), new PointF(10.0f, TextYFloatOffset));
                TextYFloatOffset += 20.0f;
            }
        }

        public void ResetTextOffset()
        {
            TextYFloatOffset = 10.0f;
            GraphicsContext.Clear(Color.Transparent);
        }

        public bool ParseCommand(string input)
        {
            string cmd = input.Trim().ToLower();
            string[] split = cmd.Split(" ");

            string[] splitparam = null;

            List<string> errors = new List<string>();

            if (split.Length == 2)
            {
                splitparam = split[1].Split(",");
            }
            else
            {
                if (split.Length > 2)
                {
                    errors.Add("Too many parameters entered/Invalid format");
                    this.PopulateErrors(errors.ToArray());
                    return;
                }

                else
                {
                    if (!input.Contains("clear") && !input.Contains("reset")){
                        if (split.Length <= 1)
                        {
                            errors.Add("No parameters entered!");
                            this.PopulateErrors(errors.ToArray());
                            return;
                        }
                    }
                }
            }

            switch (split[0])
            {
                case "circle":
                    if (splitparam.Length > 1)
                    {
                        errors.Add("Too many parameters entered!");
                    }

                    if (splitparam.Length != 1)
                    {
                        errors.Add("No parameters entered!");
                    }
                    Draw.DrawCircle(Int32.Parse(splitparam[0]));
                    break;

                case "rect":
                    if (splitparam.Length > 2)
                    {
                        errors.Add("Too many parameters entered!");
                    }
                    if (splitparam.Length != 2)
                    {
                        errors.Add("Missing parameters!");
                        return;
                    }
                    Draw.DrawRectangle(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "triangle":
                    if (splitparam.Length > 3)
                    {
                        errors.Add("Too many parameters entered!");
                    }
                    if (splitparam.Length != 3 && splitparam.Length != 1)
                    {
                        errors.Add("Missing parameters!");
                    }
                    //Draw.DrawTriangle(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]), Int32.Parse(splitparam[2]));
                    break;

                case "moveto":
                    if (splitparam.Length > 2)
                    {
                        errors.Add("Too many parameters entered!");
                    }
                    if (splitparam.Length < 2)
                    {
                        errors.Add("Missing parameters!");
                    }
                    Draw.moveTo(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "pen":
                    if (splitparam.Length > 1)
                    {
                        errors.Add("Too many parameters entered!");
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
                            errors.Add("Unknown colour");
                            break;
                    }
                    break;

                case "fill":
                   
                    if (splitparam.Length > 1)
                    {
                        errors.Add("Too many parameters!");
                        return false;
                    }
                    if (splitparam.Length != 1)
                    {
                        errors.Add("Missing parameters!");
                        return false;
                    }
                    if (splitparam[0].Equals("1"))
                    {
                        Draw.FillToTrue();
                    }
                    if (splitparam[0].Equals("0"))
                    {
                        Draw.FillToFalse();
                    }
                   
                    break;

                case "drawto":
                    if (splitparam.Length > 2)
                    {
                        errors.Add("Too many parameters entered!");
                    }    
                    if (splitparam.Length != 2)
                    {
                        errors.Add("Missing parameters!");
                    }
                    Draw.drawTo(Int32.Parse(splitparam[0]), Int32.Parse(splitparam[1]));
                    break;

                case "reset":
                    Draw.moveTo(0, 0);
                    Draw.GetGraphics().Clear(Color.Transparent);
                    TextYFloatOffset = 10.0f;
                    break;

                case "clear":
                    TextYFloatOffset = 10.0f;
                    break;

                default:
                    errors.Add("Invalid Command");
                    break;
            }
            if(errors.Count > 0)
            {
                this.PopulateErrors(errors.ToArray());
            }
            





        }
    }
}
