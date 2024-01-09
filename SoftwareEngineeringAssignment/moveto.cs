using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class moveto : ICanvasCommand
    {
        private int x, y;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public moveto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Move the cursor to position x,y
        /// </summary>
        public void Execute(Canvas canvas)
        {
            canvas.MoveTo(x, y);
            canvas.updateCursor(); // Update cursor position after moving
        }
    }
}