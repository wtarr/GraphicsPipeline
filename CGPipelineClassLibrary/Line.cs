using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public class Line
    {
        #region Class State
        private double x1 = 0, y1 = 0, z1 = 0, x2 = 0, y2 = 0, z2 = 0;
        private double tolerence = 0.001;         
        #endregion

        #region Properties            
        public double X1
        {
            get { return x1; }
            set { x1 = value; }
        }

        public double Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public double Z1
        {
            get { return z1; }
            set { z1 = value; }
        }

        public double X2
        {
            get { return x2; }
            set { x2 = value; }
        }  

        public double Y2
        {
            get { return y2; }
            set { y2 = value; }
        }

        public double Z2
        {
            get { return z2; }
            set { z2 = value; }
        }       

        #endregion

        /// <summary>
        /// Constructor to create a 2d line
        /// </summary>
        /// <param name="_x1">X1</param>
        /// <param name="_y1">Y1</param>
        /// <param name="_x2">X2</param>
        /// <param name="_y2">Y2</param>
        #region Constructor        
        public Line(double _x1, double _y1, double _x2, double _y2)
        {
            X1 = _x1;
            Y1 = _y1;
            X2 = _x2;
            Y2 = _y2;
        }

        /// <summary>
        /// Constructor to create 3d line
        /// </summary>
        /// <param name="_x1">X1</param>
        /// <param name="_y1">Y1</param>
        /// <param name="_z1">Z1</param>
        /// <param name="_x2">X2</param>
        /// <param name="_y2">Y2</param>
        /// <param name="_z2">Z2</param>
        public Line(double _x1, double _y1, double _z1, double _x2, double _y2, double _z2)
        {
            X1 = _x1;
            Y1 = _y1;
            Z1 = _z1;

            X2 = _x2;
            Y2 = _y2;
            Z2 = _z2;
        } 

        #endregion

        /// <summary>
        /// Equals compares this line to a supplied other line 
        /// and checks if they are the same to a tolerance of 0.001
        /// </summary>
        /// <param name="obj">The line to test against</param>
        /// <returns>The result the result of the comparsion - True/False</returns>
        #region Equals
        public override bool Equals(object obj)
        {
            Line l = (Line)obj;            
            double diffX1 = l.X1 - this.X1;
            double diffY1 = l.Y1 - this.Y1;
            double diffX2 = l.X2 - this.X2;
            double diffY2 = l.Y2 - this.Y2;

            if (diffX1 < tolerence &&
                diffY1 < tolerence &&
                diffX2 < tolerence &&
                diffY2 < tolerence)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
