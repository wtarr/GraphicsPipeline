using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CGPipelineClassLibrary
{
    public class Model : IModel
    {
        #region Class state
        private List<Dictionary<String, Line>> LineListDictionary; 
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        #region Constructor
        public Model()
        {
            LineListDictionary = new List<Dictionary<string, Line>>();
        } 
        #endregion


        /// <summary>
        /// Loads a model from a given path and converts it to a list of lines with mapping.
        /// Assuming a wireframe model is being used.
        /// </summary>
        /// <param name="path">path to the file that is to be loaded</param>
        /// <returns>List of lines with tagging</returns>
        #region ModelLoader
        List<Dictionary<string, Line>> IModel.ModelLoader(string path)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
