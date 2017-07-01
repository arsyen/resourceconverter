using System;
using System.Text;
using ResourceConverter.Core;

namespace ResourceConverter.Services
{
    /// <summary>
    /// Class implementing translation operations from English to Hsilgne
    /// </summary>
    public class EnglishtToHsilgneTranslator : ITextTranslator
    {
        /// <summary>
        /// Translates text from English to Hsilgne
        /// </summary>
        /// <param name="input">Input text to translate</param>
        /// <param name="keepFirstLetterRegister">Indicates whether needed to keep first letter register</param>
        /// <returns>Translated text</returns>
        public string Translate(string input, bool keepFirstLetterRegister)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);

            StringBuilder builder = new StringBuilder(new string(arr));

            if (keepFirstLetterRegister)
            {
                if (Char.IsUpper(input[0]))
                    builder[0] = Char.ToUpper(builder[0]);
                if (Char.IsLower(input[input.Length - 1]))
                    builder[input.Length - 1] = Char.ToLower(builder[input.Length - 1]);
            }

            return builder.ToString();
        }
    }
}
