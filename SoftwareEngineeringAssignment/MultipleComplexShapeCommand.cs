using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class MultipleComplexShapesCommand : ICanvasCommand
    {
        //variable declaration
        private int numberOfShapes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="numberOfShapes"></param>
        public MultipleComplexShapesCommand(int numberOfShapes)
        {
            this.numberOfShapes = numberOfShapes;
        }

        /// <summary>
        /// Draws multiple complex shapes
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.MultipleComplexShapes(numberOfShapes);
        }
    }
}
