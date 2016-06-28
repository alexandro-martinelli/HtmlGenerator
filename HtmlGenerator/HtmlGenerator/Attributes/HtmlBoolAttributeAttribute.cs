using System;

namespace HtmlGenerator.Attributes
{
    public class HtmlBoolAttributeAttribute : HtmlAttributeAttribute
    {
        public bool InsertIfValue { get; set; }
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }
    }
}
