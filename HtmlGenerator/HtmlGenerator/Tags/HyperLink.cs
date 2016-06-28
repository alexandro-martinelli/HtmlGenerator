using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    [HtmlTag(Name = "a")]
    public class HyperLink : HtmlTextContainer
    {
        [HtmlAttribute(Name = "download")]
        public string DownloadFileName { get; set; }
        [HtmlAttribute(Name = "href")]
        public string Url { get; set; }
        [HtmlAttribute(Name = "hreflang")]
        public string UrlLanguage { get; set; }
        [HtmlAttribute]
        public string Media { get; set; }
        [HtmlAttribute(Name = "rel")]
        public Relationship Relationship { get; set; }
        [HtmlAttribute]
        public Target Target { get; set; }
        [HtmlAttribute]
        public string Type { get; set; }
    }
}
