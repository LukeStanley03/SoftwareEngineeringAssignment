using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class circle : ICanvasCommand
    {
        private int radius;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="radius"></param>
        public circle(int radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Draw the circle with radius 
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.Circle(radius);
        }
    }
}

