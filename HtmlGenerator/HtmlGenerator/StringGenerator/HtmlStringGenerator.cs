using System;
using System.Reflection;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;
using System.Collections.Generic;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.StringGenerator
{
    public class HtmlStringGenerator
    {
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

        public string ToHtmlString(object pObject)
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
                HtmlStringGenerator lGenerator = new HtmlStringGenerator();
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
                        string lValue = (string)lProperty.GetValue(CurrentObject);
                        if (HtmlHelper.NotNullOrEmpty(lValue))
                        {
                            return lValue;
                        }
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
                    if (lValue == lBoolAttribute.InsertIfValue)
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
                    lMappedProperty = HtmlHelper.NotNullOrEmpty(lAttributeValue) && (lAttributeValue != "0");
                    if (lMappedProperty)
                    {
                        lAttributeName = ((HtmlAttributeAttribute)lAttribute).Name;
                    }

                    break;
                }
                else if (lAttribute is HtmlAnonymousAttributeAttribute)
                {
                    lMappedProperty = false;
                    lAnonymousAttribute += ExtractHtmlAttributesFromAnonymousObjects((List<object>)pProperty.GetValue(CurrentObject));
                    break;
                }
                else if (lAttribute is HtmlTagedAttribute)
                {
                    lMappedProperty = false;
                    lAnonymousAttribute += ExtractHtmlFromTagedObject(pProperty.GetValue(CurrentObject));
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

        private string ExtractHtmlFromTagedObject(object pObject)
        {
            return "taged object not implemented yet";
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
                    return lAttribute.Value;
                    }
                    return lField.Name.ToLower();
                }
            }
            return "";
        }
    }

}
