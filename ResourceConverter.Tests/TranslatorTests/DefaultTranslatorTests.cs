using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResourceConverter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class DefaultTranslatorTests
    {

        [TestMethod()]
        public void TranslateTest_NoUppercase()
        {
            //Arrange
            DefaultTranslator translator = new DefaultTranslator();

            //Act
            string result1 = translator.Translate("Sample_string", false);
            string result2 = translator.Translate("Sample_strinG", false);
            string result3 = translator.Translate("sample_string", false);

            //Assert
            Assert.AreEqual("Sample_string", result1);
            Assert.AreEqual("Sample_strinG", result2);
            Assert.AreEqual("sample_string", result3);
        }

        [TestMethod()]
        public void TranslateTest_Uppercase()
        {
            //Arrange
            DefaultTranslator translator = new DefaultTranslator();

            //Act
            string result1 = translator.Translate("Sample_string", true);
            string result2 = translator.Translate("Sample_strinG", true);
            string result3 = translator.Translate("sample_string", true);

            //Assert
            Assert.AreEqual("Sample_string", result1);
            Assert.AreEqual("Sample_strinG", result2);
            Assert.AreEqual("sample_string", result3);
        }
    }
}
