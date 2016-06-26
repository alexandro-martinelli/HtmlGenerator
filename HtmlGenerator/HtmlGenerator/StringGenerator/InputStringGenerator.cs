using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator
{
    public abstract class InputStringGenerator : HtmlTagStringGenerator
    {
        protected override sealed string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            Input lInput = (Input)pHtmlTag;
            string lHtml = DoConvertSelfAttributes(lInput);
            if (lInput.AutoFocus) {
                lHtml += ConcatOnlyAttribute("autofocus");
            }
            if (lInput.ReadOnly)
            {
                lHtml += ConcatOnlyAttribute("readonly");
            }
            if (lInput.Required)
            {
                lHtml += ConcatOnlyAttribute("required");
            }
            lHtml += ConcatAttributeWithValue("autocomplete", UsageToString(lInput.AutoComplete));
            lHtml += ConcatAttributeWithValue("value", lInput.Value);
            return lHtml;
        }

        protected virtual string DoConvertSelfAttributes(Input pInput)
        {
            return "";
        }

        protected override sealed string GetHtmlTagName()
        {
            return "input";
        }

    }
}
