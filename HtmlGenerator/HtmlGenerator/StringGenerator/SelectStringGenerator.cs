using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator
{
    public class SelectStringGenerator : HtmlTagStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }
        protected override string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            Select lSelect = (Select)pHtmlTag;
            MasterStringGenerator lGenerator = new MasterStringGenerator();
            string lHtml = "";
            foreach (Option lOption in lSelect.Options)
            {
                lHtml += lGenerator.ToHtmlString(lOption);
            }
            return lHtml;
        }

        protected override string GetHtmlTagName()
        {
            return "select";
        }
    }
}
