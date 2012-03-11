using System.IO;
using System.Xml;
using NUnit.Framework;


namespace Simple.Http.Tests
{
    [TestFixture]
    public class DynamicXmlSerializerTests
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            Reader = XmlReader.Create(new StringReader("<post><id>5</id><description>test</description></post>"));
        }

        #endregion

        private XmlReader Reader { get; set; }

        [Test]
        public void DeserializeShouldReturnACorrectlyPopulatedDynamicObject()
        {
            var serializer = new DynamicXmlSerializer();
            var result = serializer.Deserialize(Reader);
            Assert.AreEqual(5, result.ID);
        }

        [Test]
        public void DeserializeShouldReturnObjectsWithCorrectlyParsedStringProperties()
        {
            var serializer = new DynamicXmlSerializer();
            var result = serializer.Deserialize(Reader);
            Assert.AreEqual("test", result.Description);
        }
    }
}