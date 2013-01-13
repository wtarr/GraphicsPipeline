using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CGPipelineClassLibrary
{
    public class ModelTransformation : IModelTransformation
    {        
        /// <summary>
        /// A method that will rotate a wireframe model at delta radians about a given axis
        /// </summary>
        /// <param name="model">The model to rotate</param>
        /// <param name="delta">the angle in radians</param>
        /// <param name="axis">Axis to rotate about</param>
        /// <returns>A rotated model</returns>
        #region Rotate
        public Model Rotate(Model model, float delta, Axis axis)
        {
            throw new NotImplementedException();
        } 
        #endregion

        /// <summary>
        /// A method that will Scale a wireframe model to a factor at a given axis
        /// </summary>
        /// <param name="model">The model to scale</param>
        /// <param name="scalevalue">The value at which to scale</param>
        /// <param name="axis">the axis to scale to</param>
        /// <returns>A scaled model</returns>
        #region Scale
        public Model Scale(Model model, float scalevalue, Axis axis)
        {
            throw new NotImplementedException();
        } 
        #endregion

        /// <summary>
        /// A method that will Transform a wireframe model to a given axis
        /// </summary>
        /// <param name="model">The model to transform</param>
        /// <param name="transformvalue">The amount to transfrom by</param>
        /// <param name="axis">The axis at which to transform to</param>
        /// <returns>A transformed model</returns>
        #region Translate
        public Model Translate(Model model, float transformvalue, Axis axis)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
