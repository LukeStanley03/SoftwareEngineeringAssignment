using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class complexshape : ICanvasCommand
    {
        /// <summary>
        /// Draws a complex shape
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.ComplexShape();
        }
    }

}
