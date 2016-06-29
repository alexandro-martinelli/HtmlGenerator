
using System;
using HtmlGenerator.Commons;

namespace HtmlGenerator.StringGenerator
{
    public class MasterStringGenerator : CustomStringGenerator
    {
        public override string ToHtmlString(object pObject)
        {
            string lHtml = "";
            HtmlTagStringGenerator lGenerator = new HtmlTagStringGenerator();
            lHtml = lGenerator.ToHtmlString(pObject);
            return lHtml;
        }
    }


}
