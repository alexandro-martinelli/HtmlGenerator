using System;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    public class Image : FormInput
    {
        protected override InputType GetInputType()
        {
            return InputType.Image;
        }
        [HtmlAttribute(Name = "src")]
        public string Source { get; set; }
        [HtmlAttribute]
        public double Height { get; set; }
        [HtmlAttribute]
        public double Width { get; set; }
        [HtmlAttribute(Name = "alt")]
        public string AlternateText { get; set; }
    }
}
