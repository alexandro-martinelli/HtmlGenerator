using System;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    public class Number : NumberedInput
    {
        public string Interval { get; set; }

        protected override InputType GetInputType()
        {
            return InputType.Number;
        }
        [HtmlAttribute(Name = "maxlength")]
        public int MaximunLength { get; set; }
        [HtmlAttribute]
        public int Size { get; set; }
    }
}
