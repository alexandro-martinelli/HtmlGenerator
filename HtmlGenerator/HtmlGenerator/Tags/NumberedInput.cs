
using HtmlGenerator.Attributes;
using HtmlGenerator.Enums;
namespace HtmlGenerator.Tags
{
    public abstract class NumberedInput : Input
    {
        [HtmlAttribute(Name = "max")]
        public string MaximunValue { get; set; }
        [HtmlAttribute(Name = "min")]
        public string MinimunValue { get; set; }
    }
}
