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
                    lHtml += string.Format(" {0}=\"{1}\"", lProperty.Name, lProperty.GetValue(pHtmlAttributes).ToString());
                }
            }
            return lHtml;
        }
    }
}
