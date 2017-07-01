namespace ResourceConverter.Core
{
    public interface ITextTranslator 
    {
        /// <summary>
        /// When implemented translates text from English to Hsilgne
        /// </summary>
        /// <param name="input">Input text to translate</param>
        /// <param name="keepFirstLetterRegister">Indicates whether needed to keep first letter register</param>
        /// <returns>Translated text</returns>
        string Translate(string input, bool keepFirstLetterRegister);
    }
}
