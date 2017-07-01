using System.Collections.Generic;
using ResourceConverter.Core.Models;

namespace ResourceConverter.Core
{
    /// <summary>
    /// Provides resource repository functionality
    /// </summary>
    public interface IResourceProvider
    {
        /// <summary>
        /// When implemented gets resource records from source file
        /// </summary>
        /// <param name="path">Source file path</param>
        /// <returns>List of all records</returns>
        List<ResXRecord> GetRecords(string path);

        /// <summary>
        /// When implemented saves resources into destination file 
        /// </summary>
        /// <param name="path">Destination file path</param>
        /// <param name="records">List of records to save</param>
        void WriteRecords(string path, List<ResXRecord> records);
    }
}
