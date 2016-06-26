using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Number : NumberedInput
    {
        public string Interval { get; set; }

        protected override InputType GetInputType()
        {
            return InputType.Number;
        }

        public int MaximunLength { get; set; }
        public int Size { get; set; }
    }
}
