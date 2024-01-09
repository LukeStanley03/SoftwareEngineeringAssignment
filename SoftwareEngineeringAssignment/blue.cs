using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class blue : ICanvasCommand
    {
        
        public void Execute(Canvas canvas)
        {
            canvas.BlueColour();
        }
    }
}