using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyclingApp
{
    /// <summary>
    /// Interface representing the file reader allows for processing of different types of files
    /// </summary>
    interface IFileReader
    {
        /// <summary>
        /// Method to read the file
        /// </summary>
        /// <param name="filePath">The Path to the file</param>
        void ReadFile(string filePath);

        /// <summary>
        /// Function to separeate the data from the file
        /// </summary>
        void SeparateData();

    }
}
