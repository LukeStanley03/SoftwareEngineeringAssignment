using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEngineeringAssignment
{
    public interface ICanvas
    {
        void Circle(int radius);
    }


    /// <summary>
    /// Canvas class to holds information that is displayed on the 
    /// picture box in response to simple programming language commands
    /// </summary>
    public class Canvas : ICanvas
    {
        //Standard size of canvas
        const int XSIZE = 640;
        const int YSIZE = 480;

        //instance data for pen and x, y positions and graphics context
        //graphics context is the drawing area to draw on
        Form CallingForm;
        Graphics g, cursorG;
        int XCanvasSize, YCanvasSize;
        Pen pen;
        public int xPos, yPos; // pen position when drawing

        protected Color background_colour = Color.Gray;

        public bool fill = false;

        //Graphics g;
        //Pen pen = new Pen(Color.Black, 1);        
        //int xPos = 0, yPos = 0; // pen position when drawing

        Point penPosition = new Point(10, 10);
        Color penColour;

        //Variables to handle animated star




        public Canvas()
        {
            XCanvasSize = XSIZE;
            YCanvasSize = YSIZE;
        }

        /// <summary>
        /// Constructor initialises canvas to black pen at 0,0
        /// </summary>
        /// <param name="g">Graphics context of place to draw on</param>
        public Canvas(Form CallingForm, Graphics gin, Graphics cursorG)
        {
            this.g = gin;
            this.cursorG = cursorG;
            XCanvasSize = XSIZE;
            YCanvasSize = YSIZE;
            xPos = yPos = 0;
            pen = new Pen(Color.Black, 2);

            this.CallingForm = CallingForm;
        }

        /// <summary>
        /// Constructor initialises canvas of set size to black pen at 0,0
        /// </summary>
        /// <param name="CallingForm"></param>
        /// <param name="gin">Graphics context of place to draw on</param>
        /// <param name="xsize">width of canvas</param>
        /// <param name="ysize">height of canvas</param>
        public Canvas(Form CallingForm, Graphics gin, int xsize, int ysize)
        {
            this.g = gin;
            XCanvasSize = xsize;
            YCanvasSize = ysize;
            pen = new Pen(Color.Black, 1);
            xPos = yPos = 0;
            this.CallingForm = CallingForm;
        }

        /// <summary>
        /// read only property for xpos of cursor
        /// </summary>
        public int Xpos
        {
            get
            {
                return xPos;
            }
        }

        /// <summary>
        /// read only property for ypos of cursor
        /// </summary>
        public int Ypos
        {
            get
            {
                return yPos;
            }
        }


        /// <summary>
        /// move the cursor display to the current drawing position
        /// </summary>
        public void updateCursor()
        {
            cursorG.Clear(Color.Transparent);
            Pen p = new Pen(Color.Red, 1);
            cursorG.DrawRectangle(p, xPos, yPos, 4, 4);
            CallingForm.Refresh();
        }

        /// <summary>
        /// sets the RGB colours
        /// </summary>
        /// <param name="red">integer value of red</param>
        /// <param name="green">integer value of green</param>
        /// <param name="blue">integer value of blue</param>
        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
                throw new GPLexception("Invalid colour");
            penColour = Color.FromArgb(red, green, blue);
            pen = new Pen(penColour, 1);
        }

        /// <summary>
        /// Moves pen position
        /// </summary>
        /// <param name="x">position x</param>
        /// <param name="y">position y</param>
        public void MoveTo(int x, int y)
        {
            penPosition = new Point(x, y);

            if (x < 0 || x > XCanvasSize || y < 0 || y > XCanvasSize)
                throw new GPLexception("invalid screen position Canvas.MoveTo");
            //update the pen position as it has moved to the end of the line
            xPos = x;
            yPos = y;
        }

        /// <summary>
        /// draw a line from current pen position (xPos,yPos)
        /// </summary>
        /// <param name="toX">x position to draw to</param>
        /// <param name="toY">y position to draw to</param>
        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toY < 0 || toX > XCanvasSize)
                throw new GPLexception("invalid screen position Canvas.DrawTo");
            if (g != null) //if from a unit test then g will be null
                //draw the line
                g.DrawLine(pen, xPos, yPos, toX, toY);

            //update the pen position as it has moved to the end of the line
            xPos = toX;
            yPos = toY;
        }

        /// <summary>
        /// draw a square 
        /// </summary>
        /// <param name="width">size of the square length</param>
        public void Square(int width)
        {
            if (width < 0)
                throw new GPLexception("Invalid square width");

            if (g != null)
            {
                if (fill)
                {
                    //fill the square
                    g.FillRectangle(pen.Brush, xPos - width / 2, yPos - width / 2, width, width);
                }
                else
                {
                    //draw the square
                    g.DrawRectangle(pen, xPos, yPos, width, width);
                }
            }

        }

        /// <summary>
        /// draws rectangle
        /// </summary>
        /// <param name="width">width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        public void Rectangle(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new GPLexception("Invalid rectangle width and height");

            if (g != null)
            {
                if (fill)
                {
                    //fill the rectangle
                    g.FillRectangle(pen.Brush, xPos - width / 2, yPos - width / 2, width, height);
                }
                else
                {
                    //draw the rectangle
                    g.DrawRectangle(pen, xPos - width / 2, yPos - width / 2, width, height);
                }
            }

        }

        /// <summary>
        /// draws triangle
        /// </summary>
        /// <param name="width">width of the triangle</param>
        /// <param name="height">height of the triangle</param>
        public void Triangle(int width, int height)
        {
            if (width < 0 || height < 0)
                throw new GPLexception("Invalid rectangle width and height");

            //Points used to draw the triangle
            Point[] points = { new Point(xPos, yPos - height / 2), new Point(xPos - width / 2, yPos + height / 2), new Point(xPos + width / 2, yPos + height / 2) };

            if (g != null)
            {
                if (fill)
                {
                    //fill the triangle
                    g.FillPolygon(pen.Brush, points);
                }
                else
                {
                    //draw the triangle
                    g.DrawPolygon(pen, points);
                }
            }
        }

        /// <summary>
        /// draws a circle
        /// </summary>
        /// <param name="radius">radius of the circle</param>
        public virtual void Circle(int radius)
        {
            if (radius < 0)
                throw new GPLexception("invalid circle radius");

            if (g != null)
            {
                if (fill)
                {
                    //fill the circle
                    g.FillEllipse(pen.Brush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
                else
                {
                    //draw the circle
                    g.DrawEllipse(pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
            }

        }


        /// <summary>
        /// Sets colour to red
        /// </summary>
        public void RedColour()
        {
            pen = new Pen(Color.Red, 1);
        }

        /// <summary>
        /// Sets colour to green
        /// </summary>
        public void GreenColour()
        {
            pen = new Pen(Color.Green, 1);
        }

        /// <summary>
        /// Sets colour to blue
        /// </summary>
        public void BlueColour()
        {
            pen = new Pen(Color.Blue, 1);
        }

        /// <summary>
        /// Sets colour to black
        /// </summary>
        public void BlackColour()
        {
            pen = new Pen(Color.Black, 1);
        }

        /// <summary>
        /// makes shapes filled and not outlined
        /// </summary>
        /// <param name="input">Choice of either on or off</param>
        public void SetFill(string input)
        {
            if (input.Equals("on") == true)
            {
                fill = true;
            }
            else if (input.Equals("off") == true)
            {
                fill = false;
            }
            else
                throw new GPLexception("invalid fill parameter");
        }

        /// <summary>
        /// Clears the drawing area
        /// </summary>
        public void Clear()
        {
            g.Clear(background_colour);
        }

        /// <summary>
        /// Moves pen to initial position at the top left of the screen
        /// </summary>
        public void Reset()
        {
            xPos = 0;
            yPos = 0;
        }


        /// ADDITIONAL FUNCTIONALITY SECTION

        /// <summary>
        /// ADDITIONAL 1
        /// Draws a complex shape
        /// </summary>
        public void ComplexShape()
        {
            // Create the path for the shape
            GraphicsPath path = new GraphicsPath();
            path.AddLines(new Point[] {
                new Point(40, 140), new Point(275, 200),
                new Point(105, 225), new Point(190, 300),
                new Point(50, 350), new Point(20, 180)
            });
            path.CloseFigure();

            // Create a path gradient brush and set its properties
            PathGradientBrush pgb = new PathGradientBrush(path);
            pgb.SurroundColors = new Color[] { Color.Green, Color.Yellow, Color.Red, Color.Blue, Color.Orange, Color.White };

            // Create a path gradient brush and set its properties
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, XCanvasSize, YCanvasSize));

            // Fill the path with the gradient
            g.FillPath(pgb, path);
        }


        /// <summary>
        /// ADDITIONAL 2
        /// Draws mulptiple complex shapes
        /// </summary>
        /// <param name="numberOfShapes"></param>
        public void MultipleComplexShapes(int numberOfShapes)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfShapes; i++)
            {
                // Generate random parameters for each shape
                int x = random.Next(XCanvasSize);
                int y = random.Next(YCanvasSize);
                int sizeModifier = random.Next(1, 10); // Example size modifier
                string colorHex = String.Format("#{0:X6}", random.Next(0x1000000)); // Random color

                // Draw each complex shape
                ComplexShapeAt(x, y, sizeModifier, ColorTranslator.FromHtml(colorHex));
            }
        }

        private void ComplexShapeAt(int x, int y, int sizeModifier, Color color)
        {
            // Define the points of your complex shape, scaling and positioning them based on x, y, and sizeModifier
            Point[] points = new Point[]
            {
                new Point(x + sizeModifier * 40, y + sizeModifier * 140),
                new Point(x + sizeModifier * 275, y + sizeModifier * 200),
                new Point(x + sizeModifier * 105, y + sizeModifier * 225),
                new Point(x + sizeModifier * 190, y + sizeModifier * 300),
                new Point(x + sizeModifier * 50, y + sizeModifier * 350),
                new Point(x + sizeModifier * 20, y + sizeModifier * 180)
            };

            // Create a GraphicsPath and add the points to it
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            path.CloseFigure();

            // Create a PathGradientBrush for coloring
            PathGradientBrush pgb = new PathGradientBrush(path);
            pgb.SurroundColors = new Color[] { color, Color.Yellow, Color.Red, Color.Blue, Color.Orange, Color.White };

            // Fill the path with the specified color and pattern
            g.FillPath(pgb, path);
        }

        /// <summary>
        /// ADDITIONAL 3
        /// Draws random lines with random colours
        /// </summary>
        /// <param name="numberOfLines"></param>
        public void RandomLines(int numberOfLines)
        {
            Random rnd = new Random();
            for (int i = 0; i < numberOfLines; i++)
            {
                // Generate random start and end points
                int startX = rnd.Next(0, XCanvasSize);
                int startY = rnd.Next(0, YCanvasSize);
                int endX = rnd.Next(0, XCanvasSize);
                int endY = rnd.Next(0, YCanvasSize);

                // Generate random color
                Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                Pen randomPen = new Pen(randomColor);

                // Draw the line with the random color
                g.DrawLine(randomPen, startX, startY, endX, endY);
            }
        }

        /// <summary>
        /// Calculates the points of the star and draw it
        /// </summary>
        /// <param name="outerRadius">star outer radius</param>
        /// <param name="innerRadius">star inner radius</param>
        /// <param name="numPoints">star's number of points</param>
        public void Star(int outerRadius, int innerRadius, int numPoints)
        {
            //Check for any unexpected scenarios:
            if (numPoints < 5 || outerRadius <= innerRadius || outerRadius <= 0 || innerRadius <= 0)
            {
                throw new GPLexception("Invalid parameters for drawing a star.");
            }

            // Center of the canvas
            Point center = new Point(XCanvasSize / 2, YCanvasSize / 2);

            PointF[] points = new PointF[numPoints * 2];
            double angleStep = Math.PI / numPoints;
            double startAngle = 0; // Adjust if needed

            for (int i = 0; i < numPoints * 2; i += 2)
            {
                // Outer point
                points[i].X = center.X + (float)(outerRadius * Math.Cos(startAngle + i * angleStep));
                points[i].Y = center.Y + (float)(outerRadius * Math.Sin(startAngle + i * angleStep));

                // Inner point
                points[i + 1].X = center.X + (float)(innerRadius * Math.Cos(startAngle + (i + 1) * angleStep));
                points[i + 1].Y = center.Y + (float)(innerRadius * Math.Sin(startAngle + (i + 1) * angleStep));
            }

            // Draw the star
            if (fill)
            {
                g.FillPolygon(new SolidBrush(pen.Color), points);
            }
            else
            {
                g.DrawPolygon(pen, points);
            }



        }


        /// <summary>
        /// ADDITIONAL 5
        /// Draws the pattern
        /// </summary>
        public void Pattern()
        {
            int w = XSIZE;
            int h = YSIZE;

            for (int i = 0; i < w; i += 5)
                g.DrawLine(Pens.Red, i, 0, w - i, h);

            for (int i = 0; i < h; i += 5)
                g.DrawLine(Pens.Red, w, i, 0, h - i);

        }
    }
}