using HtmlGenerator.Commons;
using HtmlGenerator.Tags;

namespace HtmlGenerator.StringGenerator
{
    public class LabelStringGenerator : HtmlTextContainerStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            Label lLabel = (Label)pHtmlTag;
            string lHtml = ConcatAttributeWithValue("for", lLabel.For);
            lHtml += ConcatAttributeWithValue("form", lLabel.Form);
            return lHtml;
        }

        protected override string GetHtmlTagName()
        {
            return "label";
        }
    }




}
