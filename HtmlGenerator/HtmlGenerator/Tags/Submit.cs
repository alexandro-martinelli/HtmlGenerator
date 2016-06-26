using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Submit : Input
    {
        protected override InputType GetInputType()
        {
            return InputType.Submit;
        }
    }
}
