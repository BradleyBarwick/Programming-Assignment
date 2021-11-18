using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        Canvas Canvas;
        Parser Parser;
        Script Script;
        public Form1()
        {
            InitializeComponent();
            ScreenX = 640;
            ScreenY = 480;
            OutputBitmap = new Bitmap(ScreenX, ScreenY);
            Graphics GraphicsObject = Graphics.FromImage(OutputBitmap);
            Canvas = new Canvas(GraphicsObject);
            Parser = new Parser(GraphicsObject);
            Script = new Script(GraphicsObject);

        }

        private void CommandLine_TextChanged(object sender, EventArgs e)
        {

        }

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

                Parser.ParseCommand(CommandLine.Text);
                CommandLine.Text = "";
                Refresh();
            }

           
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(OutputBitmap, 0, 0);
        }
    }
}
