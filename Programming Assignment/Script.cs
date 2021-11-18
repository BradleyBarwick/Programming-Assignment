using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Programming_Assignment
{
    public class Script : Parser
    {
        public new bool ParseCommand(string input)
        {
            string script = input.ToLower().Trim();
            string[] commands = script.Split("\n");


            base.ResetTextOffset();
            foreach (string command in commands)
            {
                if (base.ParseCommand(command))
                    return true;
                else
                {
                    return false;
                }
            }
            return true;
        }
        public Script(Graphics g) : base(g){}
    }
}
