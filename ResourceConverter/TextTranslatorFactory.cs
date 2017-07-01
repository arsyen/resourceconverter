using ResourceConverter.Core;
using ResourceConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceConverter
{
    public class TextTranslatorFactory
    {
        public static ITextTranslator GetTranslator(TranslatorType type)
        {
            switch (type)
            {
                case TranslatorType.EngToHsilgne: return new EnglishtToHsilgneTranslator();
                default: return new DefaultTranslator();
            }
        }
    }
}
