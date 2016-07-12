using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AsyncLib
{
    public class BingRequest:IImageRequest
    {
        private const string AppId = "uU19nR0sgND2HjJ8co8eZW+d4FS5GBYUHp/PPCIbDx0";

        public int Count { get; set; }
        public int Offset { get; set; }
        public BingRequest()
        {
            Count = 50;
            Offset = 0;
        }

        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set { searchTerm = value; }
        }


        public string Url => $"https://api.datamarket.azure.com/Data.ashx/Bing/Search/v1/Image?Query=%27{SearchTerm}%27&$top={Count}&$skip={Offset}&$format=Atom";

        public IEnumerable<SearchItemResult> Parse(string xml)
        {
            XElement respXml = XElement.Parse(xml);
            // XNamespace atom = XNamespace.Get("http://www.w3.org/2005/Atom");
            XNamespace d = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices");
            XNamespace m = XNamespace.Get("http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");

            return (from item in respXml.Descendants(m + "properties")
                    select new SearchItemResult
                    {
                        Title = new string(item.Element(d + "Title").Value.Take(50).ToArray()),
                        Url = item.Element(d + "MediaUrl").Value,
                        ThumbnailUrl = item.Element(d + "Thumbnail").Element(d + "MediaUrl").Value,
                        Source = "Bing"
                    }).ToList();
        }

        public ICredentials Credentials => new NetworkCredential(AppId,AppId);
    }
}
