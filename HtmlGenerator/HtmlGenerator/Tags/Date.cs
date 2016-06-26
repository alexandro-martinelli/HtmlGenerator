using System;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Date : NumberedInput
    {
        protected override InputType GetInputType()
        {
            return InputType.Date;
        }

    }
}
