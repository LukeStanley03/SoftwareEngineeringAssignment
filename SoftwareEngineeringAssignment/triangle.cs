﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineeringAssignment
{
    public class triangle : ICanvasCommand
    {
        private int width;
        private int height;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public triangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Draw a triangle with width and height
        /// </summary>
        /// <param name="canvas"></param>
        public void Execute(Canvas canvas)
        {
            canvas.Triangle(width, height);
        }
    }
}
