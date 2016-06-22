using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class ListOption : HtmlTag
    {
        public string Label { get; set; }
        public bool Selected { get; set; }
        public string Text { get; set; }
    }
}
