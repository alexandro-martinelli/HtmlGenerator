using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Text : Input
    {
        protected override InputType GetInputType()
        {
            return InputType.Text;
        }
    }
}
