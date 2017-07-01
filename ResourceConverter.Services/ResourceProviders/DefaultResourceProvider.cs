using System.Collections.Generic;
using System.Resources;
using System.ComponentModel.Design;
using System.Collections;
using ResourceConverter.Core;
using ResourceConverter.Core.Models;
using NLog;
using System.IO;

namespace ResourceConverter.Services
{
    /// <summary>
    /// Implements repository methods for ResX resources
    /// </summary>
    public class DefaultResourceProvider : IResourceProvider
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets resource records from source file
        /// </summary>
        /// <param name="path">Source file path</param>
        /// <returns>List of all records</returns>
        public List<ResXRecord> GetRecords(string path)
        {
            logger.Info($"Reading records from: {path}");

            //Read from source file
            ResXResourceReader sourceResourceReader = new ResXResourceReader(path);
            sourceResourceReader.UseResXDataNodes = true;
            IDictionaryEnumerator dict = sourceResourceReader.GetEnumerator();
            Dictionary<string, string> sourceResources = new Dictionary<string, string>();

            List<ResXRecord> records = new List<ResXRecord>();
            while (dict.MoveNext())
            {
                ResXDataNode node = (ResXDataNode)dict.Value;
                records.Add(new ResXRecord
                {
                    Key = node.Name,
                    Value = node.GetValue((ITypeResolutionService)null).ToString(),
                    Comment = node.Comment
                });
            };

            sourceResourceReader.Close();
            return records;
        }

        /// <summary>
        /// Saves resources into destination file 
        /// </summary>
        /// <param name="path">Destination file path</param>
        /// <param name="records">List of records to save</param>
        public void WriteRecords(string path, List<ResXRecord> records)
        {
            logger.Info($"Saving records to: {path}");

            if (File.Exists(path))
            {
                logger.Error("Destination path already exist.");
                throw new IOException("Destination file already exist");
            }

            //Write to destination file
            ResXResourceWriter destResourceWriter = new ResXResourceWriter(path);

            foreach (ResXRecord record in records)
            {
                ResXDataNode node = new ResXDataNode(record.Key, record.Value);
                node.Comment = record.Comment;
                destResourceWriter.AddResource(node);
            }
            destResourceWriter.Generate();
            destResourceWriter.Close();
        }
    }
}
