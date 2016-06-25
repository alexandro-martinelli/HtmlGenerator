
using System;
using HtmlGenerator.Commons;

namespace HtmlGenerator.StringGenerator
{
    public class MasterStringGenerator : CustomStringGenerator
    {
        public override string ToHtmlString(HtmlTag pHtmlTag)
        {
            string lHtml = "";
            CustomStringGenerator lGenerator = StringGeneratorRegister.GetRegisteredGeneratorForClass(pHtmlTag.GetType().Name);
            if (lGenerator != null)
            {
                lHtml = lGenerator.ToHtmlString(pHtmlTag);
            }
            return lHtml;
        }
    }


}
