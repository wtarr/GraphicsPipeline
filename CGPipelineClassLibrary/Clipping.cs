using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public class Clipping : IClipping
    {
        /// <summary>
        /// Allows for the clipping of a line against the standard axies
        /// </summary>
        /// <param name="line">The line to be clipped</param>
        /// <returns>A clipped line or null if outside the clipping plane</returns>
        #region ClipLine
        public Line ClipLine(Line line)
        {

            int[] outcode1 = new int[4];
            int[] outcode2 = new int[4];
            CalculateOutcode(line, out outcode1, out outcode2);

            int trivalAccept = LogicalAnd(outcode1, outcode2);

            if (trivalAccept == 1)
            {
                return line;
            }
            else if (trivalAccept == 0)
            {
                //Work to do
                Line newLine = PerformClip(line, outcode1, outcode2);
                return newLine;
            }
            else
            {
                return null;
            }

        } 
        #endregion

        /// <summary>
        /// Allows for the clipping of a line formed by two XNA Vector2
        /// </summary>
        /// <param name="vector1">Vector1</param>
        /// <param name="vector2">Vector2</param>
        /// <returns>A clipped line or null if outside the clipping plane</returns>
        #region ClipLine
        public Line ClipLine(Microsoft.Xna.Framework.Vector2 v1, Microsoft.Xna.Framework.Vector2 v2)
        {
            Line convertedLine = new Line(v1.X, v1.Y, v2.X, v2.Y);
            return ClipLine(convertedLine);
        }
        #endregion

        /// <summary>
        /// Calculates the outcodes of the line
        /// </summary>
        /// <param name="line">The line in question</param>
        /// <param name="outcodepoint1">(OUT) outcode for the first point</param>
        /// <param name="outcodepoint2">(OUT) outcode for the second point</param>
        #region CalculateOutcode
        private void CalculateOutcode(Line line, out int[] outcodepoint1, out int[] outcodepoint2)
        {
            outcodepoint1 = new int[4];
            outcodepoint2 = new int[4];

            //UDLR
            //Up
            outcodepoint1[0] = line.Y1 > 1 ? 1 : 0;
            //Down
            outcodepoint1[1] = line.Y1 < -1 ? 1 : 0;
            //Left
            outcodepoint1[2] = line.X1 < -1 ? 1 : 0;
            //Right
            outcodepoint1[3] = line.X1 > 1 ? 1 : 0;

            //UDLR
            //Up
            outcodepoint2[0] = line.Y2 > 1 ? 1 : 0;
            //Down
            outcodepoint2[1] = line.Y2 < -1 ? 1 : 0;
            //Left
            outcodepoint2[2] = line.X2 < -1 ? 1 : 0;
            //Right
            outcodepoint2[3] = line.X2 > 1 ? 1 : 0;


        } 
        #endregion

        /// <summary>
        /// Performs a logical And of the two supplied outcodes and returns a result of whether clipping is required.
        /// </summary>
        /// <param name="o1">Outcode for point 1</param>
        /// <param name="o2">Outcode for point 2</param>
        /// <returns>Result</returns>
        #region LogicalAnd
        private int LogicalAnd(int[] o1, int[] o2)
        {
            // 1 -  Triv accept
            // 0 -  Reject
            //-1 -  Work to do

            int[] and = new int[4];
            int result = 1;

            and[0] = o1[0] & o2[0];
            and[1] = o1[1] & o2[1];
            and[2] = o1[2] & o2[2];
            and[3] = o1[3] & o2[3];

            if (o1.Contains(1)) result = 0;
            if (o2.Contains(1)) result = 0;
            if (and.Contains(1)) result = -1;

            return result;


        } 
        #endregion

        /// <summary>
        /// Performs the actual clipping if required and returns a new clipped line
        /// </summary>
        /// <param name="line">The line to be clipped</param>
        /// <param name="o1">The outcode for point 1</param>
        /// <param name="o2">The outcode for point 2</param>
        /// <returns>The clipped line or null if outside clipping plane</returns>
        #region PerformClip
        private Line PerformClip(Line line, int[] o1, int[] o2)
        {
            double x1 = line.X1;
            double y1 = line.Y1;

            double x2 = line.X2;
            double y2 = line.Y2;

            // Slope of line
            double m = (line.Y2 - line.Y1) / (line.X2 - line.X1);

            ClipToAxis(o1, line, out x1, out y1, m, x1, y1);
            ClipToAxis(o2, line, out x2, out y2, m, x2, y2);

            if (x1 > 1 || x1 < -1 || x2 > 1 || x2 < -1 || y1 > 1 || y1 < -1 || y2 > 1 || y2 < -1)
                return null;
            else
                return new Line(x1, y1, x2, y2);
        } 
        #endregion

        /// <summary>
        /// Submethod to the Perform clip - Performs the clipping calculation and returns a new X Y coordinate
        /// </summary>
        /// <param name="outcode">Outcode for the point in question</param>
        /// <param name="line">The line in question</param>
        /// <param name="x">(OUT) new X coord</param>
        /// <param name="y">(OUT) new Y coord</param>
        /// <param name="m">Slope m</param>
        /// <param name="inX">X point of the line in question</param>
        /// <param name="inY">Y point of the line in question</param>
        #region ClipToAxis
        private void ClipToAxis(int[] outcode, Line line, out double x, out double y, double m, double inX, double inY)
        {
            x = inX;
            y = inY;


            // Axis to clip against
            int axisx = 0;
            int axisy = 0;

            if (outcode[0] == 1) axisy = 1;  //up 
            if (outcode[1] == 1) axisy = -1; //down
            if (outcode[2] == 1) axisx = -1; //left
            if (outcode[3] == 1) axisx = 1;  //right

            if (axisy != 0)
            {
                //equation of line and clip against y axis
                x = ((axisy - line.Y1) / m) + line.X1;
                y = axisy;

                // if x1 > 1 try with the other axis too axisx
                if (x > 1 || x < -1)
                {
                    x = axisx;
                    y = line.Y1 + (m * (axisx - line.X1));
                }
            }

            // It may be within, if so leave it alone
            if ((x > 1 || x < -1 || y > 1 || y < -1) && (axisx != 0))
            {
                x = axisx;
                y = line.Y1 + (m * (axisx - line.X1));

                // if x1 > 1 try with the other axis too axisx
                if (x > 1)
                {
                    x = ((axisy - line.Y1) / m) + line.X1;
                    y = axisy;
                }

            }
        } 
        #endregion
                
    }
}
