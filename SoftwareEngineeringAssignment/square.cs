using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class square : ICanvasCommand
    {
        private int width;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        public square(int width)
        {
            this.width = width;
        }

        /// <summary>
        /// Draw a square with width
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.Square(width);
        }
    }
}
