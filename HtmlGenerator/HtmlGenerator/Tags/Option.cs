using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    [HtmlTag]
    public class Option : HtmlTag
    {
        [HtmlAttribute]
        public string Label { get; set; }
        [HtmlAttribute]
        public bool Selected { get; set; }
        [HtmlAttribute]
        public string Value { get; set; }
        [HtmlText]
        public string Text { get; set; }
    }
}
