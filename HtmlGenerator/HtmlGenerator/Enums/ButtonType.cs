using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum ButtonType
    {
        [HtmlEnumValue(Value = "button")]
        Button,
        [HtmlEnumValue(Value = "reset")]
        Reset,
        [HtmlEnumValue(Value = "submit")]
        Submit
    }
}
