﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class updatecursor : ICanvasCommand
    {
        /// <summary>
        /// Locate cursor to the current position
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.updateCursor();
        }
    }

}
