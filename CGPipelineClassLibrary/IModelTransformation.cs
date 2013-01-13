using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
   
    public interface IModelTransformation
    {
        /// <summary>
        /// Will rotate a wireframe model at delta radians about a given axis
        /// </summary>
        /// <param name="model">The model to transform</param>
        /// <param name="delta">the angle in radians</param>
        /// <param name="axis">Axis to rotate about</param>
        /// <returns>A rotated model</returns>
        Model Rotate(Model model, float delta, Axis axis);

        /// <summary>
        /// Will Scale a wireframe model to a factor at a given axis
        /// </summary>
        /// <param name="model">The model to scale</param>
        /// <param name="scalevalue">The value at which to scale</param>
        /// <param name="axis">the axis to scale to</param>
        /// <returns>A transformed list of lines with mapping</returns>
        Model Scale(Model model, float scalevalue, Axis axis);

        /// <summary>
        /// Transform a wireframe model to a given axis
        /// </summary>
        /// <param name="model">The model to transform</param>
        /// <param name="transformvalue">The amount to transfrom by</param>
        /// <param name="axis">The axis at which to transform to</param>
        /// <returns>A transformed list of lines with mapping</returns>
        Model Translate(Model model, float transformvalue, Axis axis);
    }
}
