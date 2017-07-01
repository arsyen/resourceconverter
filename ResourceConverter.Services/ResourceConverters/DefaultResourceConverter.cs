using System.Collections.Generic;
using System.IO;
using NLog;
using ResourceConverter.Core;
using ResourceConverter.Core.Models;

namespace ResourceConverter.Services
{
    /// <summary>
    /// Default resource converter
    /// </summary>
    public class DefaultResourceConverter : IResourceConverter
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IResourceProvider resourceProvider;

        /// <summary>
        /// Initiates DefaultResourceConverter object
        /// </summary>
        /// <param name="resourceProvider">Resource provider to get/save resources</param>
        public DefaultResourceConverter(IResourceProvider resourceProvider)
        {
            logger.Info($"Initializing {nameof(DefaultResourceConverter)}");
            this.resourceProvider = resourceProvider;
        }

        /// <summary>
        /// Converts resource values and creates new resource file with new values
        /// </summary>
        /// <param name="fromPath">Source file path</param>
        /// <param name="toPath">Destination file path</param>
        /// <param name="textTranslator">Text transalator to translate resource values</param>
        public void Convert(string fromPath, string toPath, ITextTranslator textTranslator)
        {
            logger.Info("Starting file convertion");

            List<ResXRecord> records =  resourceProvider.GetRecords(fromPath);

            foreach(ResXRecord record in records)
            {
                record.Value = textTranslator.Translate(record.Value, true);
            }

            resourceProvider.WriteRecords(toPath, records);

            logger.Info("File convertion completed");
        }
    }
}
