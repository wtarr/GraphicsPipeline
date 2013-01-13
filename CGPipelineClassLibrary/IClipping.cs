using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CGPipelineClassLibrary
{
    public interface IClipping
    {
        /// <summary>
        /// Allows for the clipping of a line against the standard axies
        /// </summary>
        /// <param name="line">The line to be clipped</param>
        /// <returns>A clipped line or null if outside the clipping plane</returns>
        Line ClipLine(Line line);

        /// <summary>
        /// Allows for the clipping of a line formed by two XNA Vector2
        /// </summary>
        /// <param name="vector1">Vector1</param>
        /// <param name="vector2">Vector2</param>
        /// <returns>A clipped line or null if outside the clipping plane</returns>
        Line ClipLine(Vector2 vector1, Vector2 vector2);
    }
}
