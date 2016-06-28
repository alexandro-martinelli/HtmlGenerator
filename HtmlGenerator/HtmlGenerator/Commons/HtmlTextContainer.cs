using HtmlGenerator.Attributes;

namespace HtmlGenerator.Commons
{
    public class HtmlTextContainer : HtmlContainer
    {
        [HtmlText]
        public string Text { get; set; }
    }
}
