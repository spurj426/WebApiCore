using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Xml.XPath;

namespace WebApiCore.Services.Strategy.Values
{
    /// <summary>
    /// The Xml mapper has a schema dependency which must be known in advance.
    /// </summary>
    public class XmlMapper : IValuesMapper
    {
        public IEnumerable<string> MapResponse(object input)
        {
            List<string> values = new List<string>();

            XPathDocument xPathDoc;

            var ms =
                new MemoryStream(System.Text.Encoding.UTF8.GetBytes(HttpUtility.HtmlDecode(input.ToString())));
            using (ms)
            {
                xPathDoc = new XPathDocument(ms);
            }

            // Create a navigator for the xpath doc
            XPathNavigator xPathNav = xPathDoc.CreateNavigator();
            xPathNav.MoveToRoot();
            xPathNav.MoveToFirstChild();
            xPathNav.MoveToFirstChild();

            do
            {
                xPathNav.MoveToAttribute("desc", string.Empty);
                values.Add(xPathNav.Value);
                xPathNav.MoveToParent();
            } while (xPathNav.MoveToNext());

            return values;
        }
    }
}
