﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public interface IRasterise
    {
        /// <summary>
        /// Takes a list of lines and rasterises them to the screen
        /// </summary>
        /// <param name="linesToRasterise">The list of lines to rasterise</param>
        /// <param name="ResX">The screen X resolution</param>
        /// <param name="ResY">The screen Y resolution</param>
        void RasteriseLines(List<Line> linesToRasterise, int ResX, int ResY);

    }
}
