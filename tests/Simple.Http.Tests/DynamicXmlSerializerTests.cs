using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;
using Simple.Http.Spike;

namespace Simple.Http.Tests
{
    [TestFixture]
    public class DynamicXmlSerializerTests
    {
        [Test]
        public void DeserializeShouldReturnACorrectlyPopulatedDynamicObject()
        {
            var reader = XmlReader.Create(new StringReader("<post><id>5</id><description>test</description></post>"));
            var serializer = new DynamicXmlSerializer();
            var result = serializer.Deserialize(reader);
            Assert.AreEqual(5, result.Id);
        }
    }
}
