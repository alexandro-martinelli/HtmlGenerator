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
            foreach (OptionGroup lGroup in lSelect.Groups)
            {
                //lHtml += lGenerator.ToHtmlString(lGroup);
                foreach (Option lOption in lGroup.Options)                
                {
                    lHtml += lGenerator.ToHtmlString(lOption);
                }
            }
            return lHtml;
        }

        protected override string GetHtmlTagName()
        {
            return "select";
        }
    }
}
