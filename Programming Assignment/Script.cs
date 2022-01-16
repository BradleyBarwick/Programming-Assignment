using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Programming_Assignment
{

    public class Script : Parser
    {
        Dictionary<string, string> Variables = null;
        bool error = false;
        private void NewVariable(string line)
        {
            string SubstitutedCommand = SubstituteCommand(line);
            
            string Key = line.Split(' ')[0].Trim();
            if (!SubstitutedCommand.Contains('+'))
            {
                string Variable = SubstitutedCommand.Split(' ')[2].Trim();
                Variables[Key] = Variable;
            }
            else
            {
                // a = a + 50
                string Variable = SubstitutedCommand.Split(' ')[2].Trim();
                bool Variable1IsNumeric = int.TryParse(SubstitutedCommand.Split(' ')[2].Trim(), out _);
                string Variable2 = SubstitutedCommand.Split(' ')[4].Trim();
                try
                {
                    if (!Variable1IsNumeric)
                    {
                        Variables[Key] = Convert.ToString(Variable + int.Parse(Variable2));
                    }
                    else
                    {
                        Variables[Key] = Convert.ToString(int.Parse(Variable) + int.Parse(Variable2));
                    }
                }
                catch (Exception)
                {
                    base.PopulateErrors(new []{ "You can only add a number to a variable! "+ line});
                }
            }
        }

        private string SubstituteCommand(string command)
        {
            string SubstitutedCommand = command;

            foreach (string key in Variables.Keys)
            {
                SubstitutedCommand = Regex.Replace(SubstitutedCommand, @"\b(" + key + @")\b", Variables[key].ToString(), RegexOptions.IgnorePatternWhitespace);
            }
            return SubstitutedCommand;
        }

        private void NewLoop(string[] commands, string times)
        {
            for(int i = 0; i < int.Parse(times); i++)
            {
                foreach (string command in commands)
                {
                    ParseCommand(command);
                }
            }
        }

        public new bool ParseCommand(string input)
        {
            string script = input.ToLower().Trim();
            string[] commands = script.Split("\r\n");
            string substitudedCommand = "";

            foreach (string command in commands)
            {
                string[] wordSplit = command.Split(' ');
                
                if (command.Contains("=") && !command.Contains("=="))
                {
                    NewVariable(command);
                    continue;
                }

                if (command.Contains("loop") && !command.Equals("endloop"))
                {
                    int LoopCommandIndex = 0;
                    int EndLoopCommandIndex = 0;
                    foreach (string loopcommand in commands)
                    {
                        if (loopcommand.Contains("loop") && !loopcommand.Equals("endloop"))
                        {
                            LoopCommandIndex = Array.IndexOf(commands, loopcommand);
                            commands[Array.IndexOf(commands, loopcommand)] = "";
                        }

                        if (loopcommand.Equals("endloop"))
                        {
                            EndLoopCommandIndex = Array.IndexOf(commands, loopcommand);
                            commands[Array.IndexOf(commands, loopcommand)] = "";
                        }
                    }
                    List<string> LoopCommands = new List<string>();
                    for (int i = LoopCommandIndex + 1; i < EndLoopCommandIndex; i++)
                    {
                        LoopCommands.Add(commands[i]);
                    }
                    NewLoop(LoopCommands.ToArray(), wordSplit[1]);
                    continue;
                }

                if (command.Contains("if"))
                {
                    string substitutedIf = SubstituteCommand(command);
                    int commandIndex = Array.IndexOf(commands, command);
                    wordSplit = substitutedIf.Split(' ');
                    try
                    {
                        switch (wordSplit[2])
                        {
                            case "==":
                                if (wordSplit[1].Equals(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            case "!=":
                                if (!wordSplit[1].Equals(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            case ">":
                                if (int.Parse(wordSplit[1]) > int.Parse(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            case "<":
                                if (int.Parse(wordSplit[1]) < int.Parse(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            default:
                                base.PopulateErrors(new[] { "Unknown Operation for If statement: " + wordSplit[2] });
                                break;
                        }
                        if (commands[commandIndex + 1] != null)
                        {
                            commands[commandIndex + 1] = "";
                            commands[commandIndex] = "";
                            continue;
                        }
                    }catch (Exception)
                    {
                        base.PopulateErrors(new[] { "Number Format Exception at: " + commands[commandIndex + 1] });
                    }
                }

                if (command.Equals("endloop"))
                { 
                    continue;
                }

                foreach (string word in wordSplit)
                {
                    substitudedCommand = SubstituteCommand(command);
                }
                if (!command.Equals(""))
                {
                    if (!base.ParseCommand(substitudedCommand))
                    {
                        error = true;
                    }
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
        public Script(Graphics g) : base(g)
        {
            Variables = new Dictionary<string, string>();
        }
    }
}
