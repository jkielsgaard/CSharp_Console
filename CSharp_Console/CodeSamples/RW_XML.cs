using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace CSharp_Console.CodeSamples
{
    /// <summary>
    /// Read and Write to a XML fil, can be use to create settings file in XML format
    /// </summary>

    public class RW_XML
    {
        /// <summary>
        /// Read XML file and get output
        /// </summary>
        /// <param name="xmlPath"></param>
        public void ReadXML(string xmlPath)
        {
            // Create an instance of the XmlSerializer specifying type and namespace.
            XmlSerializer serializer = new
            XmlSerializer(typeof(XML));

            // A FileStream is needed to read the XML document.
            FileStream fs = new FileStream(xmlPath, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);

            // Declare an object variable of the type to be deserialized.
            XML i;

            // Use the Deserialize method to restore the object's state.
            i = (XML)serializer.Deserialize(reader);
            fs.Close();

            // Write out the properties of the object.
            string data = i.Data;
        }

        /// <summary>
        /// Write to XML file
        /// </summary>
        /// <param name="data"></param>
        /// /// <param name="xmlPath"></param>
        public void WriteXML(string xmlPath, string data)
        {
            XML xml = new XML();

            xml.Data = data;

            XmlDocument myXml = new XmlDocument();
            XPathNavigator xNav = myXml.CreateNavigator();

            XmlSerializer writer = new XmlSerializer(xml.GetType());
            StreamWriter file = new StreamWriter(xmlPath);
            writer.Serialize(file, xml);
            file.Close();
        }
    }

    /// <summary>
    /// object to XML
    /// </summary>
    public class XML
    {   
        public string Data;
    }
}
