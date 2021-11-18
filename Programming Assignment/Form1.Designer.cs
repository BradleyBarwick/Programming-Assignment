
namespace Programming_Assignment
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutputWindow = new System.Windows.Forms.PictureBox();
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.ProgramWindow = new System.Windows.Forms.RichTextBox();
            this.errorbox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // OutputWindow
            // 
            this.OutputWindow.Location = new System.Drawing.Point(256, 13);
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.Size = new System.Drawing.Size(536, 442);
            this.OutputWindow.TabIndex = 0;
            this.OutputWindow.TabStop = false;
            this.OutputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputWindow_Paint);
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(12, 563);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(780, 23);
            this.CommandLine.TabIndex = 1;
            this.CommandLine.TextChanged += new System.EventHandler(this.CommandLine_TextChanged);
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // ProgramWindow
            // 
            this.ProgramWindow.Location = new System.Drawing.Point(13, 13);
            this.ProgramWindow.Name = "ProgramWindow";
            this.ProgramWindow.Size = new System.Drawing.Size(223, 525);
            this.ProgramWindow.TabIndex = 2;
            this.ProgramWindow.Text = "";
            // 
            // errorbox
            // 
            this.errorbox.FormattingEnabled = true;
            this.errorbox.ItemHeight = 15;
            this.errorbox.Location = new System.Drawing.Point(256, 461);
            this.errorbox.Name = "errorbox";
            this.errorbox.Size = new System.Drawing.Size(536, 94);
            this.errorbox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 622);
            this.Controls.Add(this.errorbox);
            this.Controls.Add(this.ProgramWindow);
            this.Controls.Add(this.CommandLine);
            this.Controls.Add(this.OutputWindow);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OutputWindow;
        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.RichTextBox ProgramWindow;
        private System.Windows.Forms.ListBox errorbox;
    }
}

