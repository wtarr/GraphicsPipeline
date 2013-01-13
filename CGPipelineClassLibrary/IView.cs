using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public interface IView
    {
        /// <summary>
        /// Creates a camera view of the model
        /// </summary>
        /// <param name="model">The model to look at</param>
        /// <param name="lookat">The direction to look at</param>
        /// <param name="pos">The position to look from</param>
        /// <param name="up">The up vector</param>
        /// <returns>A model with the camera lookat applied</returns>
        Model CreateLookAt(Model model, Vect3 lookat, Vect3 pos, Vect3 up);
    }
}
