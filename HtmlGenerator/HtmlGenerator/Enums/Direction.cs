using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum Direction
    {
        [HtmlEnumValue(Value = "")]
        LeftToRight,
        [HtmlEnumValue(Value = "rtl")]
        RightToLeft,
        [HtmlEnumValue(Value = "auto")]
        Auto
    }
}
