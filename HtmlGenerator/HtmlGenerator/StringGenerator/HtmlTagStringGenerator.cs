using System;
using System.Reflection;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;
using System.Collections.Generic;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.StringGenerator
{
    public class HtmlTagStringGenerator : CustomStringGenerator
    {
        //old
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

        protected virtual string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }

        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            return "";
        }

        protected override string GetHtmlTagName()
        {
            return "";
        }

        //new

        private object CurrentObject;

        private Type CurrenType;

        protected string ConcatAttributeWithValue(string pAttributeName, string pAttributeValue)
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

        public sealed override string ToHtmlString(object pObject)
        {
            CurrentObject = pObject;
            return MakeHtmlString();
        }

        private string MakeHtmlString()
        {
            CurrenType = CurrentObject.GetType();
            string lTagName = GetHtmlTagNameFromCurrentType();
            string lHtml = "";
            if (lTagName != "")
            {
                string lTagAttributes = ExtractTagAttributes();
                if (lTagAttributes != "")
                {
                    lHtml = HtmlHelper.EncapsuleBeginTag(lTagName, lTagAttributes);
                }
                string lTagText = ExtractTagText();
                string lTagItems = ExtractTagItems();
                lHtml += lTagItems + lTagText;
                lHtml += HtmlHelper.EncapsuleEndTag(lTagName);
            }
            return lHtml;
        }

        private string GetHtmlTagNameFromCurrentType()
        {
            MemberInfo lMemberInfo = CurrenType.GetTypeInfo();
            IEnumerable<Attribute> lAttributes = CurrenType.GetTypeInfo().GetCustomAttributes();
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
                lTagName = CurrenType.Name.ToLower();
            }
            return lTagName;
        }

        private string ExtractTagItems()
        {
            IEnumerable<PropertyInfo> lProperties = CurrenType.GetRuntimeProperties();
            List<HtmlItems> lItemsList = new List<HtmlItems>();
            foreach (PropertyInfo lProperty in lProperties)
            {
                IEnumerable<Attribute> lAttributes = lProperty.GetCustomAttributes();
                foreach (Attribute lAttribute in lAttributes)
                {
                    if (lAttribute is HtmlItemsAttribute)
                    {
                       if (lProperty.GetValue(CurrentObject) is HtmlItems)
                        {
                            lItemsList.Add((HtmlItems)lProperty.GetValue(CurrentObject));
                            break;
                        }
                    }
                }
            }
            string lHtml = "";
            foreach (HtmlItems lItems in lItemsList)
            {
                HtmlTagStringGenerator lGenerator = new HtmlTagStringGenerator();
                foreach (object lItem in lItems)
                {

                    lHtml += lGenerator.ToHtmlString(lItem);
                }
            }
            return lHtml;
        }

        private string ExtractTagText()
        {
            IEnumerable<PropertyInfo> lProperties = CurrenType.GetRuntimeProperties();
            foreach (PropertyInfo lProperty in lProperties)
            {
                IEnumerable<Attribute> lAttributes = lProperty.GetCustomAttributes();
                foreach (Attribute lAttribute in lAttributes)
                {
                    if (lAttribute is HtmlTextAttribute)
                    {
                        return lProperty.GetValue(CurrentObject).ToString();
                    }
                }    
            }
            return "";
        }

        private string ExtractTagAttributes()
        {
            IEnumerable<PropertyInfo> lProperties = CurrenType.GetRuntimeProperties();
            string lTagAttributes = "";
            foreach (PropertyInfo lProperty in lProperties)
            {
                lTagAttributes += ExtractHtmlAttributeFromProperty(lProperty);
            }

            return lTagAttributes;
        }

        private string ExtractHtmlAttributeFromProperty(PropertyInfo pProperty)
        {
            string lAttributeValue = "";
            string lAttributeName = "";
            string lAnonymousAttribute = "";
            bool lMappedProperty = false;
            IEnumerable<Attribute> lAttributes = pProperty.GetCustomAttributes();
            foreach (Attribute lAttribute in lAttributes)
            {
                if (lAttribute is HtmlNoValueAttributeAttribute)
                {
                    bool lValue = (bool)pProperty.GetValue(CurrentObject);
                    if (lValue)
                    {
                        lMappedProperty = true;
                        lAttributeName = ((HtmlNoValueAttributeAttribute)lAttribute).Name;
                    }
                    break;
                }
                else if (lAttribute is HtmlBoolAttributeAttribute)
                {
                    bool lValue = (bool)pProperty.GetValue(CurrentObject);
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
                else if (lAttribute is HtmlAttributeAttribute)
                {
                    var lValue = pProperty.GetValue(CurrentObject);
                    lMappedProperty = true;
                    if (pProperty.PropertyType.GetTypeInfo().IsEnum)
                    {
                        lAttributeValue = ExtractHtmlValueFromEnum(pProperty);
                    }
                    else
                    {
                        if (lValue != null)
                        {
                            lAttributeValue = lValue.ToString();
                        }
                    }
                    lMappedProperty = (lAttributeValue != "") && (lAttributeValue != "0");
                    lAttributeName = ((HtmlAttributeAttribute)lAttribute).Name;
                    break;
                }
                else if (lAttribute is HtmlAnonymousAttributeAttribute)
                {
                    lMappedProperty = false;
                    lAnonymousAttribute += ExtractHtmlAttributesFromAnonymousObjects((List<object>)pProperty.GetValue(CurrentObject));
                    break;
                }
                
            }
            if ((lMappedProperty) && (!HtmlHelper.NotNullOrEmpty(lAttributeName)))
            {
                lAttributeName = pProperty.Name.ToLower();
            }
            string lHtml = "";
            if (lAttributeName != "")
            {
                if (lAttributeValue != "")
                {
                    lHtml = ConcatAttributeWithValue(lAttributeName, lAttributeValue);
                }
                else
                {
                    lHtml = ConcatOnlyAttribute(lAttributeName);
                }
            }
            else
            {
                lHtml += lAnonymousAttribute;
            }
            return lHtml;
        }

        private string ExtractHtmlAttributesFromAnonymousObjects(List<object> pObjectList)
        {
           string lHtml = "";
            foreach (object lObject in pObjectList)
            {
                lHtml += HtmlHelper.AnonymousObjectToHtmlAttribute(lObject);
            }
            return lHtml;
        }

        private string ExtractHtmlValueFromEnum(PropertyInfo pProperty)
        {
            string lHtml = "";
            IEnumerable<FieldInfo> lFields = pProperty.PropertyType.GetRuntimeFields();
            foreach (FieldInfo lField in lFields)
            {
                if (lField.Name.ToLower().Equals(pProperty.GetValue(CurrentObject).ToString().ToLower()))
                {
                    IEnumerable<HtmlEnumValueAttribute> lAtributes = lField.GetCustomAttributes<HtmlEnumValueAttribute>();
                    foreach (HtmlEnumValueAttribute lAttribute in lAtributes)
                    {
                        lHtml = lAttribute.Value;
                        break;

                    }
                    break;
                }
            }
            return lHtml;
        }
    }

}
