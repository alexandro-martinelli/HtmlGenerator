using System;
using System.Reflection;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;

namespace HtmlGenerator.StringGenerator
{
    public abstract class HtmlTagStringGenerator : CustomStringGenerator
    {
        protected internal string ConcatAttributeWithValue(string pAttributeName, string pAttributeValue)
        {
            return HtmlHelper.ConcatAttributeWithValue(pAttributeName, pAttributeValue);
        }

        protected string ConcatOnlyAttribute(string pAttributeName)
        {
            if (HtmlHelper.NotNullOrEmpty(pAttributeName))
            {
                return " " + pAttributeName;
            }
            return "";
        }

        protected string EnumToString(Type pEnum)
        {
            pEnum.GetRuntime

            return "";
        } 

        protected string UsageToString(Usage pUsage)
        {
            string lUsage = "";
            switch (pUsage)
            {
                case Usage.True:
                    lUsage = true.ToString();
                    break;
                case Usage.False:
                    lUsage = false.ToString();
                    break;
            }
            return lUsage;
        }

        protected string ConvertFormOptionsToHtmlAttributes(FormOptions pOptions)
        {
            string lAttributes = ConcatAttributeWithValue("Form", pOptions.Forms);
            lAttributes += ConcatAttributeWithValue("formaction", pOptions.Action);
            lAttributes += ConcatAttributeWithValue("formenctype", FormEncodeTypeToString(pOptions.EncodeType));
            lAttributes += ConcatAttributeWithValue("formmethod", FormMethodToString(pOptions.Method));
            if (pOptions.FormNoValidade)
            {
                lAttributes += ConcatOnlyAttribute("formnovalidate");
            }
            lAttributes += ConcatAttributeWithValue("formtarget", TargetToString(pOptions.Target));
            return lAttributes;
        }

        protected string TargetToString(Target pTarget)
        {
            switch (pTarget)
            {
                case Target.Blank:
                    return "_blank";
                case Target.Parent:
                    return "_parent";
                case Target.Self:
                    return "_self";
                case Target.Top:
                    return "_top";
            }
            return "";
        }

        private string FormMethodToString(FormMethod pMethod)
        {
            switch (pMethod)
            {
                case FormMethod.Get:
                    return "get";
                case FormMethod.Post:
                    return "post";
            }
            return "";

        }

        private static string FormEncodeTypeToString(FormEncodeType pEncode)
        {
            switch (pEncode)
            {
                case FormEncodeType.ApplicationFormEncoded:
                    return "application/x-www-form-urlencoded";
                case FormEncodeType.MultipartFormData:
                    return  "multipart/form-data";
                case FormEncodeType.TextPlain:
                    return "text/plain";
            }
            return "";
        }

        protected string ConvertBaseAttributes(HtmlTag pHtmlTag)
        {
            string lHtml = ConcatAttributeWithValue("accesskey", pHtmlTag.AccessKey);
            lHtml += ConcatAttributeWithValue("class", pHtmlTag.Class);
            lHtml += ConcatAttributeWithValue("id", pHtmlTag.Id);
            lHtml += ConcatAttributeWithValue("name", pHtmlTag.Name);
            lHtml += ConcatAttributeWithValue("pattern", pHtmlTag.Pattern);
            lHtml += ConcatAttributeWithValue("placeholder", pHtmlTag.PlaceHolder);
            lHtml += ConcatAttributeWithValue("Title", pHtmlTag.Title);
            lHtml += ConcatAttributeWithValue("Style", pHtmlTag.Style);
            if (pHtmlTag.Hidden)
            {
                lHtml += ConcatOnlyAttribute(" hidden");
            }
            if (!pHtmlTag.Translate)
            {
                lHtml += ConcatAttributeWithValue("translate", "no");
            }
            if (pHtmlTag.TabIndex > 0)
            {
                lHtml += ConcatAttributeWithValue("TabIndex", pHtmlTag.TabIndex.ToString());
            }
            if (pHtmlTag.Direction != Direction.LeftToRight)
            {
                string lDirection = pHtmlTag.Direction == Direction.RightToLeft ? "rtl" : "auto";
                lHtml += ConcatAttributeWithValue("dir", lDirection);
            }
            lHtml += ConcatAttributeWithValue("ContentEditable", UsageToString(pHtmlTag.ContentEditable));
            foreach (object lAttribute in pHtmlTag.AnotherAttributes)
            {
                lHtml += HtmlHelper.AnonymousObjectToHtmlAttribute(lAttribute);
            }
            return lHtml;
        }

        public sealed override string ToHtmlString(HtmlTag pHtmlTag)
        {
            return MakeHtmlString(pHtmlTag);
        }

        protected string MakeHtmlString(HtmlTag pHtmlTag)
        {
            string lHtml = ConvertBaseAttributes(pHtmlTag);
            lHtml += ConvertSelfAttributes(pHtmlTag);
            if (lHtml != "")
            {
                lHtml = HtmlHelper.EncapsuleBeginTag(GetHtmlTagName(), lHtml);
            }
            lHtml += ConvertMidleAttributes(pHtmlTag);
            lHtml += HtmlHelper.EncapsuleEndTag(GetHtmlTagName());
            return lHtml;
        }

        protected virtual string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }

        protected abstract string GetHtmlTagName();

        protected abstract string ConvertSelfAttributes(HtmlTag pHtmlTag);
    }

}
