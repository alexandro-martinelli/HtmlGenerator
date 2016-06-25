using HtmlGenerator.Commons;
using System;

namespace HtmlGenerator.StringGenerator
{
    public abstract class HtmlContainerStringGenerator : HtmlTagStringGenerator
    {
        protected override string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            return ConvertItems((HtmlContainer)pHtmlTag);
        }

        protected string ConvertItems(HtmlContainer pContainer)
        {
            if (pContainer.Items.Count > 0)
            {
                string lHtml = "";
                MasterStringGenerator lMaster = new MasterStringGenerator();
                foreach (HtmlTag lTag in pContainer.Items)
                {
                    lHtml += lMaster.ToHtmlString(lTag);
                }
                return lHtml;
            }
            return "";
        }

    }
}
