using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Utils;

namespace HtmlGenerator.Tags
{

    [HtmlTag]
    public class Form : HtmlContainer
    {
        [HtmlAttribute(Name = "accept-charset")]
        public string AcceptCharset { get; set; }
        [HtmlAttribute]
        public string Action { get; set; }
        [HtmlAttribute(Name = "enctype")]
        public FormEncodeType EncodeType { get; set; }
        [HtmlAttribute]
        public FormMethod Method { get; set; }
        [HtmlNoValueAttribute]
        public bool NoValidade { get; set; }
        [HtmlAttribute]
        public Target Target { get; set; }
        [HtmlBoolAttribute(Name = "autocomplete", InsertIfValue = true, TrueValue = "off")]
        public bool AutoCompleteDisabled { get; set; }
    }
}
