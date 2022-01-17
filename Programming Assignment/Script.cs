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
        //function that handles the setting of variables and variable addition
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
                    base.PopulateErrors(new []{ "You can only add a number to a variable! { var = var + num }: "+ line});
                }
            }
        }
        //uses regex to replace set variables (keys) in the text lines
        private string SubstituteCommand(string command)
        {
            string SubstitutedCommand = command;

            foreach (string key in Variables.Keys)
            {
                SubstitutedCommand = Regex.Replace(SubstitutedCommand, @"\b(" + key + @")\b", Variables[key].ToString(), RegexOptions.IgnorePatternWhitespace);
            }
            return SubstitutedCommand;
        }
        //the function that loops the commands a specified "times"
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
                    //continue in the loop in order to stop variable declaration line from reaching base.parsecommand (and erroring out)
                    continue;
                }

                if (command.Contains("loop") && !command.Equals("endloop"))
                {
                    int LoopCommandIndex = 0;
                    int EndLoopCommandIndex = 0;
                    //loop through script lines in order to find the loop command and its endloop counterpart and save the indexes in order to pick out the commands between them.
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
                            // break in order to not confuse established Indexes with later written loops
                            break;
                        }
                    }
                    if (EndLoopCommandIndex == 0)
                    {
                        base.PopulateErrors(new[] { "Loop isn't ended, \"endloop\" lines missing!"});
                        EndLoopCommandIndex = commands.Length;
                    }

                    //store commands inbetween the loop command and endloop
                    List<string> LoopCommands = new List<string>();
                    //since the loop command and the endloop line has been found we can select the difference between those lines and store them in the list
                    for (int i = LoopCommandIndex + 1; i < EndLoopCommandIndex; i++)
                    {
                        LoopCommands.Add(commands[i]);
                    }
                    //pass the list through to the newloop function in order to be looped
                    NewLoop(LoopCommands.ToArray(), wordSplit[1]);
                    //continue in order to stop loop command from reaching base.parsecommand as this would cause an error.
                    continue;
                }

                if (command.Contains("if"))
                {
                    //substitute the if statement line in case it contains set variables
                    string substitutedIf = SubstituteCommand(command);
                    //get the index of the if command in the commands array
                    int commandIndex = Array.IndexOf(commands, command);
                    //resplit the substitutedIf line appropriately
                    wordSplit = substitutedIf.Split(' ');
                    try
                    {
                        //switch depending on the operator used in the substitutedIf line
                        switch (wordSplit[2])
                        {
                            case "==":
                                if (wordSplit[1].Equals(wordSplit[3]))
                                {
                                    //commandIndex + 1 means to get the line after the initial if statement command
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
                            case ">=":
                                if (int.Parse(wordSplit[1]) >= int.Parse(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            case "<=":
                                if (int.Parse(wordSplit[1]) <= int.Parse(wordSplit[3]))
                                {
                                    ParseCommand(commands[commandIndex + 1]);
                                }
                                break;
                            default:
                                base.PopulateErrors(new[] { "Unknown Operation for If statement: " + wordSplit[2] });
                                break;
                        }
                        //empty the lines that should only be executed if the if condition is true and also empty the if statement line to stop base.parsecommand from seeing it
                        if (commands[commandIndex + 1] != null)
                        {
                            //black out the line that should only be executed if the if statement is true
                            commands[commandIndex + 1] = "";
                            commands[commandIndex] = "";
                            continue;
                        }
                        else
                        {
                            base.PopulateErrors(new[] { "If statement doesn't do anything: " + commands[commandIndex] });
                        }
                    }catch (Exception)
                    {
                        base.PopulateErrors(new[] { "Number Format Exception at: " + commands[commandIndex] });
                    }
                }

                foreach (string word in wordSplit)
                {
                    // check every word of every line to see if it contains a set variable.
                    substitudedCommand = SubstituteCommand(command);
                }
                if (!command.Equals(""))
                {
                    // every line should be adequately processed before it reaches this base.parsecommand line
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
