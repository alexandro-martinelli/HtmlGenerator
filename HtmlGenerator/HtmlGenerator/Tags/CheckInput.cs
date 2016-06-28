using HtmlGenerator.Attributes;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public abstract class CheckInput : Input
    {
        [HtmlAttribute]
        public bool Checked { get; set; }
    }

}
