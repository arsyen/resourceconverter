using ResourceConverter.Core;

namespace ResourceConverter.Services
{
    /// <summary>
    /// Class implementing default text translation operations
    /// </summary>
    public class DefaultTranslator : ITextTranslator
    {
        /// <summary>
        /// Keeps text the same (no translation)
        /// </summary>
        /// <param name="input">Input text to translate</param>
        /// <param name="keepFirstLetterRegister">Indicates whether needed to keep first letter register</param>
        /// <returns>Same input text</returns>
        public string Translate(string input, bool keepFirstLetterRegister)
        {
            return input;
        }
    }
}
