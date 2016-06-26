using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class RadioButton : CheckInput
    {
        protected override InputType GetInputType()
        {
            return InputType.Radio;
        }
    }
}
