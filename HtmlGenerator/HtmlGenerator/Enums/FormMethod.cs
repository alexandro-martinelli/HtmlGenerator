using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum FormMethod
    {
        [HtmlEnumValue(Value = "")]
        Default,
        [HtmlEnumValue(Value = "get")]
        Get,
        [HtmlEnumValue(Value = "post")]
        Post
    }
}
