using System;
using System.Collections.Generic;
using System.Reflection;

namespace HtmlGenerator.Utils
{
    public static class HtmlHelper
    {

        private const string BeginTag = "<";
        private const string EndTag = ">";
        private const string CloseTag = "/";

        public static bool NotNullOrEmpty(string pString)
        {
            return ((pString != "") && (pString != null));
        }

        public static string EncapsuleBeginTag(string pTag, string pAttributes = "")
        {
            string lHtml = BeginTag + pTag;
            if (NotNullOrEmpty(pAttributes))
            {
                lHtml += " " + pAttributes;
            }
            lHtml +=  EndTag;
            return lHtml;
        }

        public static string EncapsuleEndTag(string pTag)
        {
            return BeginTag + CloseTag + pTag + EndTag;
        }

        public static string EnclosureTag(string pTag, string pHtml, string pAttributes)
        {
            return EncapsuleBeginTag(pTag, pAttributes) + pHtml + EncapsuleEndTag(pTag);
        }

        public static string ConcatAttributeWithValue(string pAttributeName, string pAttributeValue)
        {
            if (NotNullOrEmpty(pAttributeValue) && NotNullOrEmpty(pAttributeName))
            {
                return string.Format(" {0}=\"{1}\"", pAttributeName.ToLower(), pAttributeValue);
            }
            return "";
        }

        public static string AnonymousObjectToHtmlAttribute(object pHtmlAttributes)
        {
            string lHtml = "";
            if (pHtmlAttributes != null)
            {
                Type lInfo = pHtmlAttributes.GetType();
                IEnumerable<PropertyInfo> lProperties = lInfo.GetRuntimeProperties();
                foreach (PropertyInfo lProperty in lProperties)
                {
                    lHtml += ConcatAttributeWithValue(lProperty.Name, lProperty.GetValue(pHtmlAttributes).ToString());
                }
            }
            return lHtml;
        }
    }
}
