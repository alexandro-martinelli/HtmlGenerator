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
            string lTagAttributes = ExtractTagAttributes();

            if (lTagName != "")
            {
                lHtml = HtmlHelper.EncapsuleBeginTag(lTagName, lTagAttributes);
            }
            else
            {
                lHtml = lTagAttributes;
            }

            string lTagText = ExtractTagText();
            string lTagItems = ExtractTagItems();
            lHtml += lTagItems + lTagText;
            if (lTagName != "")
            {
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
            List<object> lItemsList = new List<object>();
            foreach (PropertyInfo lProperty in lProperties)
            {
                IEnumerable<Attribute> lAttributes = lProperty.GetCustomAttributes();
                foreach (Attribute lAttribute in lAttributes)
                {
                    if (lAttribute is HtmlItemsAttribute)
                    {
                        if (IsListOfObject(lProperty.GetValue(CurrentObject)))
                        {
                            lItemsList.Add(lProperty.GetValue(CurrentObject));
                            break;
                        }
                    }
                }
            }
            string lHtml = "";
            foreach (object lItems in lItemsList)
            {
                HtmlStringGenerator lGenerator = new HtmlStringGenerator();
                Array lArray = (Array)lItems.GetType().GetRuntimeMethod("ToArray", new Type[0]).Invoke(lItems, new Type[0]);
                foreach (object lItem in lArray)
                {
                    lHtml += lGenerator.ToHtmlString(lItem);
                }
            }
            return lHtml;
        }

        private bool IsListOfObject(object pObject)
        {
            Type lBaseType = pObject.GetType();
            while (lBaseType != null)
            {
                if (lBaseType.FullName.Contains("List"))
                {
                    return true;
                }
                lBaseType = lBaseType.GetTypeInfo().BaseType;
            }
            return false;
        }

        private string ExtractTagText()
        {
            string lText = "";
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
                            lText += (lText != "" ? " " : "") + lValue;
                        }
                    }
                    else if (lAttribute is HtmlTagedAttribute)
                    {
                        if (((HtmlTagedAttribute)lAttribute).Location == TagedLocation.Text)
                        {
                            lText += (lText != "" ? " " : "") + ExtractHtmlFromTagedObject(lProperty.GetValue(CurrentObject));
                        }
                    }
                }    
            }
            return lText;
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
                    if (((HtmlTagedAttribute)lAttribute).Location == TagedLocation.Attributes)
                    {
                        lAnonymousAttribute += ExtractHtmlFromTagedObject(pProperty.GetValue(CurrentObject));
                    }
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
            if (pObject != null) {
                HtmlStringGenerator lGenerator = new HtmlStringGenerator();
                return lGenerator.ToHtmlString(pObject);
            }
            else
            {
                return ""; 
            }
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
