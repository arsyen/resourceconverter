using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ResourceConverter.Core;
using ResourceConverter.Core.Models;
using ResourceConverter.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceConverter.Tests
{
    [TestClass()]
    public class DefaultResourceConverterTests
    {
        [TestMethod()]
        public void Convert_Success()
        {
            //Arrange
            Mock<IResourceProvider> mockResourceProvider = new Mock<IResourceProvider>();
            Mock<ITextTranslator> mockTranslator = new Mock<ITextTranslator>();

            List<ResXRecord> mockRecords = new List<ResXRecord>
            {
                new ResXRecord { Key ="Key1", Value ="Value1", Comment="Comment1" },
                new ResXRecord { Key ="Key2", Value ="Value2", Comment="Comment2" },
                new ResXRecord { Key ="Key3", Value ="Value3", Comment="Comment3" }
            };

            mockResourceProvider.Setup(f => f.GetRecords(It.IsAny<string>())).Returns(mockRecords);
            mockResourceProvider.Setup(f => f.WriteRecords(It.IsAny<string>(), mockRecords)).Callback(() => { });
            mockTranslator.Setup<string>(f => f.Translate(It.IsAny<string>(), It.IsAny<bool>())).Returns("");

            DefaultResourceConverter converter = new DefaultResourceConverter(mockResourceProvider.Object);
            
            //Act 
            converter.Convert("samplePath1", "samplePath2", mockTranslator.Object);

            //Assert
            mockTranslator.Verify(foo => foo.Translate(It.IsAny<string>(), It.IsAny<bool>()), Times.Exactly(mockRecords.Count));

        }

        [TestMethod()]
        [ExpectedException(typeof(IOException), "Destination file already exist")]
        public void Convert_IOException()
        {
            //Arrange
            Mock<IResourceProvider> mockResourceProvider = new Mock<IResourceProvider>();
            Mock<ITextTranslator> mockTranslator = new Mock<ITextTranslator>();

            List<ResXRecord> mockRecords = new List<ResXRecord>
            {
                new ResXRecord { Key ="Key1", Value ="Value1", Comment="Comment1" },
                new ResXRecord { Key ="Key2", Value ="Value2", Comment="Comment2" },
                new ResXRecord { Key ="Key3", Value ="Value3", Comment="Comment3" }
            };

            mockResourceProvider
                .Setup(f => f.GetRecords(It.IsAny<string>())).Returns(mockRecords);

            mockResourceProvider
                .Setup(f => f.WriteRecords(It.IsAny<string>(), mockRecords))
                .Throws(new IOException("Destination file already exist"));

            mockTranslator.Setup<string>(f => f.Translate(It.IsAny<string>(), It.IsAny<bool>())).Returns("");

            DefaultResourceConverter converter = new DefaultResourceConverter(mockResourceProvider.Object);

            //Act 
            converter.Convert("samplePath1", "samplePath2", mockTranslator.Object);
        }
        
    }
}
