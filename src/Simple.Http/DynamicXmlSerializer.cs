using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Simple.Http
{
    /// <summary>
    ///   Serializes and deserializes dynamic objects into and from XML documents.
    /// </summary>
    public class DynamicXmlSerializer : XmlSerializer
    {
        /// <summary>
        ///   Deserializes the XML document contained by the specified System.Xml.XmlReader
        /// </summary>
        /// <param name="reader"> The System.Xml.XmlReader that contains the XML document to deserialize </param>
        /// <returns> A <see cref="System.Dynamic">dynamic</see> object containing the results of the serialization </returns>
        public new dynamic Deserialize(XmlReader reader)
        {
            var xmlDoc = XDocument.Load(reader);

            if (xmlDoc.Root == null)
            {
                throw new ArgumentException("Reader does not point to a valid XML document", "reader");
            }

            dynamic result = new ExpandoObject();
            var resultInfo = (IDictionary<string, object>) result;

            foreach (var element in xmlDoc.Root.Elements())
            {
                int i;
                object value;
                if (int.TryParse(element.Value, out i))
                {
                    value = i;
                }
                else
                {
                    value = element.Value;
                }
                var name = CodeIdentifier.MakePascal(element.Name.ToString());
                resultInfo[name] = value;
            }

            return result;
        }
    }
}