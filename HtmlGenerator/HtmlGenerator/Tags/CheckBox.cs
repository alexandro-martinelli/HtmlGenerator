using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class CheckBox : CheckInput
    {
        protected override InputType GetInputType()
        {
            return InputType.CheckBox;
        }
    }
}
