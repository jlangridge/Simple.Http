using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Simple.Http.Spike
{
    public class DynamicXmlSerializer : XmlSerializer
    {
       
        public new dynamic Deserialize(XmlReader reader)
        {
            var xmlDoc = XDocument.Load(reader);

            dynamic result = new ExpandoObject();
            result.Id = int.Parse(xmlDoc.Root.Element("id").Value);
            result.Description = xmlDoc.Root.Element("description").Value;
            return result;
        }
    }
}
