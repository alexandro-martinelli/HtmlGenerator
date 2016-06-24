using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class Option : HtmlTag
    {
        public string Label { get; set; }
        public bool Selected { get; set; }
        public string Text { get; set; }
        public int GroupId { get; set; }
    }
}
