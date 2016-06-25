using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Tags;
using HtmlGenerator.Enums;

namespace HtmlGenerator.StringGenerator
{
    public class ButtonStringGenerator : HtmlTextContainerStringGenerator
    {
        private string ButtonTypeToString(ButtonType pType)
        {
            switch (pType)
            {
                case ButtonType.Reset:
                    return "reset";
                case ButtonType.Submit:
                    return "Submit";
            }
            return "button";
        }

        protected sealed override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            Button lButton = (Button)pHtmlTag;
            string lHtml = ConcatAttributeWithValue("type", ButtonTypeToString(lButton.Type));
            lHtml += ConvertFormOptionsToHtmlAttributes(lButton.FormOptions);
            return lHtml;
        }

        protected sealed override string GetHtmlTagName()
        {
            return "button";
        }
    }
}
