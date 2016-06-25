using System;
using HtmlGenerator.Commons;

namespace HtmlGenerator.StringGenerator
{
    public class DivStringGenerator : HtmlTextContainerStringGenerator
    {
        protected override string GetHtmlTagName()
        {
            return "div";
        }
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }
    }
}
