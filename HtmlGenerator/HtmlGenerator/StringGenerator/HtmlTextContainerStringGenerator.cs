using HtmlGenerator.Commons;
using System;

namespace HtmlGenerator.StringGenerator
{
    public abstract class HtmlTextContainerStringGenerator : HtmlContainerStringGenerator
    {
        protected override string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            HtmlTextContainer lContainer = (HtmlTextContainer)pHtmlTag;
            string lHtml = ConvertItems(lContainer);
            lHtml += lContainer.Text;
            return lHtml;
        }

    }
}
