using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Number : NumberedInput
    {
        public Number() : base(InputType.Number)
        {

        }

        public string Interval { get; set; }
    }
}
