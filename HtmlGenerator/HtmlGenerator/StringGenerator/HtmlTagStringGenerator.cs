using System;
using System.Reflection;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;
using System.Collections.Generic;
using HtmlGenerator.Attributes;

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
            //pEnum.GetRuntime

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

        private string GetHtmlTagName(Type pType)
        {
            MemberInfo lMemberInfo = pType.GetTypeInfo();
            IEnumerable<Attribute> lAttributes = pType.GetTypeInfo().GetCustomAttributes();
            string lTagName = "";
            bool lIsTagHtml = false;
            foreach (Attribute lAttribute in lAttributes)
            {
                if (lAttribute is HtmlTagAttribute)
                {
                    lIsTagHtml = true;
                    lTagName = ((HtmlTagAttribute)lAttribute).Name;
                    break;
                }
            }
            if (!HtmlHelper.NotNullOrEmpty(lTagName) && (lIsTagHtml))
            {
                lTagName = pType.Name.ToLower();
            }
            return lTagName;
        }

        protected string MakeHtmlString(object pHtmlTag)
        {
            Type lType = pHtmlTag.GetType();
            string lTagName = GetHtmlTagName(lType);
            string lHtml = "";
            if (lTagName != "")
            {
                string lTagAttributes = ExtractTagAttributes(pHtmlTag, lType);
                if (lTagAttributes != "")
                {
                    lHtml = HtmlHelper.EncapsuleBeginTag(lTagName, lTagAttributes);
                }
                string lTagText = ExtractTagText(pHtmlTag, lType);
                string lTagItems = ExtractTagItems(pHtmlTag, lType);
                lHtml += lTagItems + lTagText;
                lHtml += HtmlHelper.EncapsuleEndTag(lTagName);
            }
            return lHtml;
        }

        private string ExtractTagItems(object pHtmlTag, Type lType)
        {
            IEnumerable<PropertyInfo> lProperties = lType.GetRuntimeProperties();
            List<HtmlItems> lItemsList = new List<HtmlItems>();
            foreach (PropertyInfo lProperty in lProperties)
            {
                IEnumerable<Attribute> lAttributes = lProperty.GetCustomAttributes();
                foreach (Attribute lAttribute in lAttributes)
                {
                    if (lAttribute is HtmlItemsAttribute)
                    {
                       if (lProperty.GetValue(pHtmlTag) is HtmlItems)
                        {
                            lItemsList.Add((HtmlItems)lProperty.GetValue(pHtmlTag));
                            break;
                        }
                    }
                }
            }
            string lHtml = "";
            foreach (HtmlItems lItems in lItemsList)
            {
                foreach (object lItem in lItems)
                {
                    lHtml += MakeHtmlString(lItem);
                }
            }
            return lHtml;
        }

        private string ExtractTagText(object pHtmlTag, Type pType)
        {

            IEnumerable<PropertyInfo> lProperties = pType.GetRuntimeProperties();
            foreach (PropertyInfo lProperty in lProperties)
            {
                IEnumerable<Attribute> lAttributes = lProperty.GetCustomAttributes();
                foreach (Attribute lAttribute in lAttributes)
                {
                    if (lAttribute is HtmlTextAttribute)
                    {
                        return lProperty.GetValue(pHtmlTag).ToString();
                    }
                }    
            }
            return "";
        }

        private string ExtractTagAttributes(object pHtmlTag, Type lType)
        {
            IEnumerable<PropertyInfo> lProperties = lType.GetRuntimeProperties();
            string lTagAttributes = "";
            foreach (PropertyInfo lProperty in lProperties)
            {
                lTagAttributes += ExtractHtmlAttributeFromProperty(pHtmlTag, lProperty);
            }

            return lTagAttributes;
        }

        private string ExtractHtmlAttributeFromProperty(object pHtmlTag, PropertyInfo pProperty)
        {
            string lAttributeValue = "";
            string lAttributeName = "";
            bool lMappedProperty = false;
            IEnumerable<Attribute> lAttributes = pProperty.GetCustomAttributes();
            foreach (Attribute lAttribute in lAttributes)
            {
                if (lAttribute is HtmlAttributeAttribute)
                {
                    lAttributeValue = pProperty.GetValue(pHtmlTag).ToString();
                    lMappedProperty = true;
                    lAttributeName = ((HtmlAttributeAttribute)lAttribute).Name;
                    break;
                }
                else if (lAttribute is HtmlNoValueAttributeAttribute)
                {
                    lMappedProperty = true;
                    lAttributeValue = ((HtmlNoValueAttributeAttribute)lAttribute).Name;
                    if (lAttributeValue == "")
                    {
                        lAttributeValue = pProperty.Name.ToLower();
                    }
                    lAttributeName = ((HtmlNoValueAttributeAttribute)lAttribute).Name;
                    break;
                }
                else if (lAttribute is HtmlBoolAttributeAttribute)
                {
                    bool lValue = (bool)pProperty.GetValue(pHtmlTag);
                    HtmlBoolAttributeAttribute lBoolAttribute = (HtmlBoolAttributeAttribute)lAttribute;
                    lAttributeName = ((HtmlBoolAttributeAttribute)lAttribute).Name;
                    if (lValue = lBoolAttribute.InsertIfValue)
                    {
                        lMappedProperty = true;
                        if (lValue)
                        {
                            lAttributeValue = lBoolAttribute.TrueValue;
                        }
                        else
                        {
                            lAttributeValue = lBoolAttribute.FalseValue;
                        }
                    }
                    break;
                }
                // do anomynous attributes
            }
            if ((lMappedProperty) && (lAttributeName == ""))
            {
                lAttributeName = pProperty.Name.ToLower();
            }
            if ((lAttributeValue != "") && (lAttributeName != "")) {
                return ConcatAttributeWithValue(lAttributeName, lAttributeValue);
            }
            else
            {
                return ConcatOnlyAttribute(lAttributeName);
            }
        }

        protected virtual string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }

        protected abstract string GetHtmlTagName();

        protected abstract string ConvertSelfAttributes(HtmlTag pHtmlTag);
    }

}
