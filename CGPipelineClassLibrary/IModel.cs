using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CGPipelineClassLibrary
{
    /// <summary>
    /// Loads a model from a given path and converts it to a list of lines with mapping.
    /// Assuming a wireframe model is being used.
    /// </summary>
    public interface IModel
    {
        List<Dictionary<String, Line>> ModelLoader(string path);
    }
}
