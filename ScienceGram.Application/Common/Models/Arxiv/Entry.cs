using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScienceGram.Application.Common.Models.Arxiv
{
    public class Entry
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "updated")]
        public DateTime Updated { get; set; }

        [XmlElement(ElementName = "published")]
        public DateTime Published { get; set; }

        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        [XmlElement(ElementName = "summary")]
        public string Summary { get; set; }

        [XmlElement(ElementName = "author")]
        public List<Author> Authors { get; set; }

        [XmlElement(ElementName = "doi", Namespace = "http://arxiv.org/schemas/atom")]
        public string Doi { get; set; }

        [XmlElement(ElementName = "comment", Namespace = "http://arxiv.org/schemas/atom")]
        public string Comment { get; set; }

        [XmlElement(ElementName = "journal_ref", Namespace = "http://arxiv.org/schemas/atom")]
        public string JournalRef { get; set; }

        [XmlElement(ElementName = "link")]
        public List<Link> Links { get; set; }

        [XmlElement(ElementName = "primary_category", Namespace = "http://arxiv.org/schemas/atom")]
        public Category PrimaryCategory { get; set; }

        [XmlElement(ElementName = "category")]
        public List<Category> Categories { get; set; }
    }
}
