using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    [HtmlTag]
    public class Label : HtmlTextContainer
    {
        [HtmlAttribute]
        public string For { get; set; }
        [HtmlAttribute]
        public string Form { get; set; }
    }
}
