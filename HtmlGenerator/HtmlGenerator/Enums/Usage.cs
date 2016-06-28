using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum Usage
    {
        [HtmlEnumValue(Value = "")]
        Default,
        [HtmlEnumValue(Value = "true")]
        True,
        [HtmlEnumValue(Value = "false")]
        False
    }
}
