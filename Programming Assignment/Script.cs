using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace Programming_Assignment
{

    public class Script : Parser
    {
        Dictionary<string, string> Variables = new Dictionary<string, string>();

        public void NewVariable(string line)
        {
            string Variable = line.Split(' ')[0].Trim();
            string Variable2 = line.Split(' ')[2].Trim();
            Variables[Variable] = Variable2;
        }

        public string SubstituteCommand(string command)
        {
            string SubstitutedCommand = command;

            foreach (string key in Variables.Keys)
            {
                SubstitutedCommand = Regex.Replace(SubstitutedCommand, @"\b(" + key + @")\b", Variables[key].ToString(), RegexOptions.IgnorePatternWhitespace);
            }
            return SubstitutedCommand;
        }

        public new bool ParseCommand(string input)
        {

            string script = input.ToLower().Trim();
            string[] commands = script.Split("\r\n");
            string substitudedCommand = "";
            bool error = false;

            base.ResetTextOffset();
            foreach (string command in commands)
            {
                string[] wordSplit = command.Split(' ');
                if (command.Contains("="))
                {
                    NewVariable(command);
                    continue;
                }

                foreach (string word in wordSplit)
                {
                    substitudedCommand = SubstituteCommand(command);
                }

                if (!base.ParseCommand(substitudedCommand))
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
