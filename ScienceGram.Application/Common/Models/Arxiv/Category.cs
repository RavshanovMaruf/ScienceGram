using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScienceGram.Application.Common.Models.Arxiv
{
    public class Category
    {
        [XmlAttribute(AttributeName = "term")]
        public string Term { get; set; }

        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }
    }
}
