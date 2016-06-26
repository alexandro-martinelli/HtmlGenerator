using HtmlGenerator.Commons;
using HtmlGenerator.Tags;
using System;

namespace HtmlGenerator.StringGenerator
{
    public class SpanStringGenerator : HtmlTextContainerStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
           return "";
        }

        protected override string GetHtmlTagName()
        {
            return "span";
        }
    }
}
