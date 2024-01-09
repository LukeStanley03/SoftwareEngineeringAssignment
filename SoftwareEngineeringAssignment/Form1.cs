using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEngineeringAssignment
{
    public partial class Form1 : Form
    {
        

        const int screenX = 640;
        const int screenY = 480;


        Bitmap OutputBitmap = new Bitmap(screenX, screenY); //Bitmap to draw on which will be displayed in the outputWindow
        Bitmap CursorBitmap = new Bitmap(screenX, screenY); //overlay bitmap for cursor
        Graphics bmG;
        Canvas MyCanvas;
        Parser MyParser;
        Color background_colour = Color.Gray;

        public Form1()
        {
            InitializeComponent();
            bmG = Graphics.FromImage(OutputBitmap);
            //Class for handling the drawing, pass the drawing surface to it
            MyCanvas = new Canvas(this, Graphics.FromImage(OutputBitmap), Graphics.FromImage(CursorBitmap));
            MyParser = new Parser(MyCanvas);
            MyCanvas.updateCursor();
            bmG.Clear(background_colour);
        }


        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open GPL File",
                Filter = "GPL File (*.gpl)|*.gpl"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filehandler fileHandler = new filehandler();
                    string fileContent = fileHandler.ReadFromFile(openFileDialog.FileName);
                    textBox1.Text = fileContent;
                }
                catch (GPLexception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Save GPL File",
                Filter = "GPL File (*.gpl)|*.gpl"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filehandler fileHandler = new filehandler();
                    fileHandler.WriteToFile(saveFileDialog.FileName, textBox1.Text);
                }
                catch (GPLexception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void outputWindow_Paint(object sender, PaintEventArgs e)
        {
            //get graphics context of the form
            var graphics = e.Graphics;

            //put the off screen bitmaps on the form
            graphics.DrawImageUnscaled(OutputBitmap, x: 0, y: 0);
            graphics.DrawImageUnscaled(CursorBitmap, x: 0, y: 0);
        }

        private void commandLine_KeyDown(object sender, KeyEventArgs e)
        {
            // Processing only if the user has clicked the Enter key
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true; // no beep noise made

            // Get the input from the user
            String input = commandLine.Text.Trim();

            // Clear the command line
            commandLine.Text = "";

            if (input.Equals("run", StringComparison.OrdinalIgnoreCase))
            {
                String program = textBox1.Text.Trim();
                string errors = MyParser.ProcessProgram(program); // programs get executed from the program window
                if (!string.IsNullOrEmpty(errors))
                {
                    // any errors get displayed
                    writeString(errors);
                }
            }
            else
            {
                
                string[] inputLines = new string[] { input };

                
                int newLineIndex = 0;

                
                bool skipExecution = false;

                
                string error = MyParser.ParseCommand(inputLines, 0, ref newLineIndex, out skipExecution); // Pass '1' as the line number

                
                if (skipExecution)
                {
                    // Handle the skipping logic if necessary
                    // For example, you might want to log a message or simply continue
                }

                if (!string.IsNullOrEmpty(error))
                {
                    // display error if there is any
                    writeString(error);
                }
            }

            // empties command line after command is entered
            commandLine.Text = "";

            // the output window gets refreshed
            outputWindow.Invalidate();

            // if there is something being draw it needs to refresh to appear
            Refresh();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            String program = textBox1.Text.Trim();

            bmG.Clear(background_colour);
            MyParser.ProcessProgram(program);

            //Clear the program window
            textBox1.Text = "";

            //update display
            Refresh();
        }

        private void syntaxButton_Click(object sender, EventArgs e)
        {
            string program = textBox1.Text;
            string errors = MyParser.ProcessProgram(program);

            if (string.IsNullOrEmpty(errors))
            {
                errors = "No syntax errors found.";
            }

           
            writeString(errors);
            outputWindow.Invalidate(); // refreshes the window
        }

        private void writeString(String text)
        {
            //Clear the output bitmap
            bmG.Clear(background_colour);

            //Create font and brush
            Font drawFont = new Font("Arial", 10);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            //Set format of string
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.NoClip;


            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            float y = 0;
            foreach (var line in lines)
            {
                bmG.DrawString(line, drawFont, drawBrush, new PointF(0, y));
                y += drawFont.Height;
            }

            // Assign the updated bitmap to the outputWindow to display the text
            outputWindow.Image = OutputBitmap;
        }
    }
}