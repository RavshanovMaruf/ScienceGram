using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScienceGram.Application.Common.Models.Arxiv
{
    public class Author
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "affiliation", Namespace = "http://arxiv.org/schemas/atom")]
        public string Affiliation { get; set; }
    }
}
