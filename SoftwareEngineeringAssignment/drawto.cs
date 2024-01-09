﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class drawto : ICanvasCommand
    {
        private int x, y;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public drawto(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Draw to position x,y
        /// </summary>
        public void Execute(Canvas canvas)
        {
            canvas.DrawTo(x, y);
            canvas.updateCursor(); // Update cursor position after drawing
        }
    }
}
