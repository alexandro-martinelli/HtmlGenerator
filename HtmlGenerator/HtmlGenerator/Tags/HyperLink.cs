using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class HyperLink : HtmlTextContainer
    {
        public string DownloadFileName { get; set; }
        public string Url { get; set; }
        public string UrlLanguage { get; set; }
        public string Media { get; set; }
        public Relationship Relationship { get; set; }
        public Target Target { get; set; }
        public string Type { get; set; }
    }
}
