using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Assignment
{
    public partial class Form1 : Form
    {
        int ScreenX;
        int ScreenY;
        

        Bitmap OutputBitmap;
        public Graphics GraphicsObject;
        public Canvas Canvas = null;
        public Parser Parser;
        public Script Script;

        protected OpenFileDialog ofd = new OpenFileDialog();
        protected SaveFileDialog sfd = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
            ScreenX = OutputWindow.Width;
            ScreenY = OutputWindow.Height;
            OutputBitmap = new Bitmap(ScreenX, ScreenY);
            GraphicsObject = Graphics.FromImage(OutputBitmap);
            Canvas = new Canvas(GraphicsObject);
            Parser = new Parser(GraphicsObject);
            Script = new Script(GraphicsObject);

        }
        /// <summary>
        /// function that triggers if specific key on the keyboard is pressed. Used for the commandline when a user wants to run a command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (CommandLine.Text.Equals("run"))
                {
                    Script.ParseCommand(ProgramWindow.Text);
                    Refresh();
                    return;
                }

                if (CommandLine.Text.Contains("clear"))
                {
                    this.GraphicsObject.Clear(Color.Transparent);
                    Refresh();
                    return;
                }
                

                Parser.ParseCommand(CommandLine.Text);
                CommandLine.Text = "";
                Refresh();
            }

           
        }
        /// <summary>
        /// output window that the drawings will be displayed onto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, ProgramWindow.Text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string line in System.IO.File.ReadLines(ofd.FileName))
                {
                    ProgramWindow.Text += line + "\n";
                }
            }
        }
    }
}

