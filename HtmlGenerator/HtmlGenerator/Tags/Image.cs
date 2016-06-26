using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Image : FormInput
    {
        protected override InputType GetInputType()
        {
            return InputType.Image;
        }

        public string Source { get; set; }
        public int Height { get; set; }
        public double Width { get; set; }
        public string AlternateText { get; set; }
    }
}
