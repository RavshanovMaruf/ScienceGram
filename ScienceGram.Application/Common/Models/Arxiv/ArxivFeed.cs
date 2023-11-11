using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScienceGram.Application.Common.Models.Arxiv
{
    [XmlRoot(ElementName = "feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class ArxivFeed
    {
        [XmlElement(ElementName = "link")]
        public List<Link> Links { get; set; }

        [XmlElement(ElementName = "title")]
        public Title Title { get; set; }

        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "updated")]
        public DateTime Updated { get; set; }

        [XmlElement(ElementName = "totalResults", Namespace = "http://a9.com/-/spec/opensearch/1.1/")]
        public int TotalResults { get; set; }

        [XmlElement(ElementName = "startIndex", Namespace = "http://a9.com/-/spec/opensearch/1.1/")]
        public int StartIndex { get; set; }

        [XmlElement(ElementName = "itemsPerPage", Namespace = "http://a9.com/-/spec/opensearch/1.1/")]
        public int ItemsPerPage { get; set; }

        [XmlElement(ElementName = "entry")]
        public List<Entry> Entries { get; set; }
    }
}
