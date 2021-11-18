using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Programming_Assignment
{
    class Script : Parser
    {
        public new void ParseCommand(string input)
        {
            string script = input.ToLower().Trim();
            string[] commands = script.Split("\n");


            base.ResetTextOffset();
            foreach (string command in commands)
            {
                base.ParseCommand(command);
            }
        }
        public Script(Graphics g) : base(g){}
    }
}
