using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator
{
    public class OptionStringGenerator : HtmlTagStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            Option lOption = (Option)pHtmlTag;
            string lHtml = ConcatAttributeWithValue("label", lOption.Label);
            lHtml += ConcatAttributeWithValue("value", lOption.Value);
            if (lOption.Selected)
            {
                lHtml += ConcatOnlyAttribute("selected");
            }
            return lHtml;
        }

        protected override string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            return ((Option)pHtmlTag).Text;
        }

        protected override string GetHtmlTagName()
        {
            return "option";
        }
    }

}
