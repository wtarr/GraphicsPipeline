using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public class Vect3
    {
        #region Class state
        private float x;
        private float y;
        private float z; 
        #endregion

        #region Properties
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        public float Z
        {
            get { return z; }
            set { z = value; }
        } 
        #endregion


    }
}
