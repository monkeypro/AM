using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

namespace BookstoreService
{
    /// <summary>
    /// Summary description for Linq
    /// </summary>
    [WebService(Namespace = "http://sogeti.se/asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Books
    {
        const string BOOKSTORE = @"c:\temp\bookstore.xml";

        [WebMethod]
        public List<XElement> GetByGenre(string genre)
        {
            var doc = XDocument.Load(BOOKSTORE);

            var books = doc.Descendants("book")
                           .Where(b => b.Element("genre").Value == genre);

            return books.ToList();
        }

        [WebMethod]
        public string GetMoreExpensiveThan(decimal price)
        {
            var doc = XDocument.Load(BOOKSTORE);

            var titles = from b in doc.Descendants("book")
                         where ToDecimal(b.Element("price")) > price
                         select b.Element("title").Value;

            return string.Join(", ", titles);
        }

        [WebMethod]
        public decimal GetAveragePrice()
        {
            var doc = XDocument.Load(BOOKSTORE);

            var average = doc.Descendants("book").Average(b => ToDecimal(b.Element("price")));

            return average;                
        }

        [WebMethod]
        public List<XElement> SetCheapest()
        {
            var doc = XDocument.Load(BOOKSTORE);

            //Hämtar ut det lägsta priset
            var cheapest = doc.Descendants("book").Min(b => ToDecimal(b.Element("price")));

            //Hämtar alla böcker som har det lägsta priset och selectar ut dem som nya XElement innehållande alla attributes och alla elements från en book + ett nytt element 'cheapest'
            var books = doc.Descendants("book")
                            .Where(b => ToDecimal(b.Element("price")) == cheapest)
                            .Select(b => new XElement("book", 
                                                        b.Attributes(),
                                                        b.Elements(),
                                                        new XElement("cheapest", "1")));

            return books.ToList(); //Observera att ändringen aldrig spara ner i filen utan endast returneras till klienten
        }

        private static decimal ToDecimal(XElement element)
        {
            //Skulle även gå att lägga som en Extension-metod på XElement
            return Convert.ToDecimal(element.Value, new CultureInfo("en-US"));
        }
    }
}
