using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class randlines : ICanvasCommand
    {
        private int numberOfLines;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfLines"></param>
        public randlines(int numberOfLines)
        {
            this.numberOfLines = numberOfLines;
        }

        /// <summary>
        /// Draws random lines
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.RandomLines(numberOfLines);
        }
    }
}
