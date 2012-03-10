using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Simple.Http.Spike
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var spike = new ServiceSpike();

            var ser = new DynamicXmlSerializer();
            var result = ser.Deserialize(new StringReader("<name>test</name>"));

            Console.WriteLine(result);
        }
    }
}
