namespace ResourceConverter.Core
{
    /// <summary>
    /// Provides resource files converion operations
    /// </summary>
    public interface IResourceConverter
    {
        /// <summary>
        /// When implemented Converts one resource file to another
        /// </summary>
        /// <param name="fromPath">Source file path</param>
        /// <param name="toPath">Destination file path/param>
        /// <param name="textTranslator">Text translator used for translation from one language to another</param>
        void Convert(string fromPath, string toPath, ITextTranslator textTranslator);
    }
}
