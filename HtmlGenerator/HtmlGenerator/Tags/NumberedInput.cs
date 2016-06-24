
using HtmlGenerator.Enums;
namespace HtmlGenerator.Tags
{
    public abstract class NumberedInput : Input
    {
        public NumberedInput(InputType pType)
            : base(pType)
        {
            
        }

        public string MaximunValue { get; set; }
        public string MinimunValue { get; set; }
    }
}
