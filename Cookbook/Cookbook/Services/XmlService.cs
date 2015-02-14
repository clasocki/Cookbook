using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;

namespace Cookbook.Services
{
    public class XmlService
    {
        public string Transform(string xmlString, string xsltPath)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            using (var stream = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto }))
                {
                    var xslTransform = new XslCompiledTransform();
                    xslTransform.Load(xsltPath);
                    xslTransform.Transform(xmlDocument, xmlWriter);
                }

                return stream.ToString();
            }
        }

        public string Transform(string xmlString, string xsltPath, List<KeyValuePair<string, object>> xsltArgs)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlString);

            var argList = new XsltArgumentList();

            xsltArgs.ForEach(argPair => argList.AddParam(argPair.Key, "", argPair.Value));

            using (var stream = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stream, new XmlWriterSettings { ConformanceLevel = ConformanceLevel.Auto }))
                {
                    var xslTransform = new XslCompiledTransform();
                    xslTransform.Load(xsltPath);
                    xslTransform.Transform(xmlDocument, argList, xmlWriter);
                }

                return stream.ToString();
            }
        }
    }
}