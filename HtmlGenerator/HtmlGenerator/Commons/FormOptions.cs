using HtmlGenerator.Attributes;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Commons
{
    public class FormOptions
    {
        [HtmlAttribute]
        public string Forms { get; set; }
        [HtmlAttribute(Name = "formaction")]
        public string Action { get; set; }
        [HtmlAttribute(Name = "formenctype")]
        public FormEncodeType EncodeType { get; set; }
        [HtmlAttribute(Name = "formmethod")]
        public FormMethod Method { get; set; }
        [HtmlNoValueAttribute]
        public bool FormNoValidade { get; set; }
        [HtmlAttribute(Name = "formtarget")]
        public Target Target { get; set; }
    }
}
