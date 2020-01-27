using System;
using System.Xml;
using System.IO;

namespace xml_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlReader xr = XmlReader.Create(@"C:\Users\student\source\repos\ishay-peleg\xml_test\xml_test\XMLFile1.xml");

            while (xr.Read())
            {
                switch (xr.NodeType)
                {
                    case XmlNodeType.XmlDeclaration:
                        Console.WriteLine("XML: {0}", xr.Value);
                        break;
                    case XmlNodeType.Element:
                        Console.Write("\n<{0}>", xr.Name);
                        if (!xr.HasAttributes)
                            Console.WriteLine();
                            break;
                    case XmlNodeType.Text:
                        Console.WriteLine(xr.Value);
                        break;
                    default:
                        break;
                }

                if (xr.HasAttributes && (xr.NodeType != XmlNodeType.XmlDeclaration))
                {
                    for (int i = 0; i < xr.AttributeCount; ++i)
                    {
                        Console.Write(" {0}", xr[i]);
                    }
                }

                if (xr.Name == "member" && (xr.NodeType == XmlNodeType.Element))
                {
                    Console.WriteLine("\n============================");
                }

                if (xr.Name == "param" && (xr.NodeType == XmlNodeType.Element))
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
