using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Programming_Assignment
{

    public class Script : Parser
    {
        
        Dictionary<string, string> variables = new Dictionary<string, string>();

        public new bool ParseCommand(string input)
        {
            string script = input.ToLower().Trim();
            string[] commands = script.Split("\r\n");

            bool error = false;

            base.ResetTextOffset();
            foreach (string command in commands)
            {
                if (!base.ParseCommand(command))
                {
                    error = true;
                }
            }
            
            if (error)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
        }
        public Script(Graphics g) : base(g){}
    }
}
