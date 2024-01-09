using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class star : ICanvasCommand
    {
        private int outerRadius;
        private int innerRadius;
        private int numPoints;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="outerRadius"></param>
        /// <param name="innerRadius"></param>
        /// <param name="numPoints"></param>
        public star(int outerRadius, int innerRadius, int numPoints)
        {
            if (numPoints < 5)
                throw new GPLexception("The number of points must be at least 5.");

            if (outerRadius <= innerRadius)
                throw new GPLexception("Outer radius must be greater than inner radius.");

            if (outerRadius <= 0 || innerRadius <= 0)
                throw new GPLexception("Radii must be positive numbers.");

            this.outerRadius = outerRadius;
            this.innerRadius = innerRadius;
            this.numPoints = numPoints;
        }

        /// <summary>
        /// Draws the star shape
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.Star(outerRadius, innerRadius, numPoints);
        }
    }
}