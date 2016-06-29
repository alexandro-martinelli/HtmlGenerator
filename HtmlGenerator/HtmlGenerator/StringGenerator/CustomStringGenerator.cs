using HtmlGenerator.Commons;

namespace HtmlGenerator.StringGenerator
{
    public abstract class CustomStringGenerator 
    {
        public abstract string ToHtmlString(object pObject);

        protected virtual string GetHtmlTagName()
        {
            return "";
        }

        protected virtual string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }
    }


}
