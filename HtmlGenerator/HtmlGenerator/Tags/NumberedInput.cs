
using HtmlGenerator.Enums;
namespace HtmlGenerator.Tags
{
    public abstract class NumberedInput : Input
    {
        public string MaximunValue { get; set; }
        public string MinimunValue { get; set; }
    }
}
