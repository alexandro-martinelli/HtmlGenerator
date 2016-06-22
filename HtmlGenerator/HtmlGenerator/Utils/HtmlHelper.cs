using System;
using System.Collections.Generic;
using System.Reflection;

namespace HtmlGenerator.Utils
{
    public static class HtmlHelper
    {

        public static string AnonymousObjectToHtmlAttribute(object pHtmlAttributes)
        {
             string lHtml = "";
            if (pHtmlAttributes != null)
            {
                Type lInfo = pHtmlAttributes.GetType();
                IEnumerable<PropertyInfo> lProperties = lInfo.GetRuntimeProperties();
                foreach (PropertyInfo lProperty in lProperties)
                {
                    lHtml += lProperty.Name;
                    lHtml += "=\"";
                    lHtml += lProperty.GetValue(pHtmlAttributes).ToString();
                    lHtml += "\"";
                }
            }
             return lHtml;
        }
    }
}
