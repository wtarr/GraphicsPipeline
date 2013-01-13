using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public interface IProjection
    {
        /// <summary>
        /// Takes a list of lines and applies the projection matrix.
        /// </summary>
        /// <param name="model">The model to have perspective matrix applied to it</param>
        /// <param name="angle">The angle of the field angle</param>
        /// <param name="nearplanedistance">The near plane distance</param>
        /// <param name="farplanedistance">The far plane distance</param>
        /// <returns>A list of lines that have had the projection matrix applied to them</returns>
        List<Dictionary<String, Line>> CreatePerspectiveFieldOfView(Model model, float angle, float nearplanedistance, float farplanedistance);
           
       
    }
}
