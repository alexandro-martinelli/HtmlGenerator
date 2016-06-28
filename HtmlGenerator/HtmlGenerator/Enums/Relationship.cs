using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum Relationship
    {
        [HtmlEnumValue(Value = "")]
        Default,
        [HtmlEnumValue(Value = "alternate")]
        Alternate,
        [HtmlEnumValue(Value = "author")]
        Author,
        [HtmlEnumValue(Value = "bookmark")]
        Bookmark,
        [HtmlEnumValue(Value = "help")]
        Help,
        [HtmlEnumValue(Value = "license")]
        License,
        [HtmlEnumValue(Value = "next")]
        Next,
        [HtmlEnumValue(Value = "nofollow")]
        NoFollow,
        [HtmlEnumValue(Value = "noreferrer")]
        NoReferrer,
        [HtmlEnumValue(Value = "prefetch")]
        Prefetch,
        [HtmlEnumValue(Value = "prev")]
        Prev,
        [HtmlEnumValue(Value = "search")]
        Search,
        [HtmlEnumValue(Value = "tag")]
        Tag
    }
}
