using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum Relationship
    {
        [HtmlEnumValue(Value = "")]
        Default,
        Alternate,
        Author,
        Bookmark,
        Help,
        License,
        Next,
        NoFollow,
        NoReferrer,
        Prefetch,
        Prev,
        Search,
        Tag
    }
}
