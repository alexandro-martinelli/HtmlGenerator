using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum Target
    {
        [HtmlEnumValue(Value = "")]
        Default,
        [HtmlEnumValue(Value = "_blank")]
        Blank,
        [HtmlEnumValue(Value = "_parent")]
        Self,
        [HtmlEnumValue(Value = "_self")]
        Parent,
        [HtmlEnumValue(Value = "_top")]
        Top
    }
}
