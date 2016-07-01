
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum CellSort
    {
        [HtmlEnumValue]
        NoSort,
        [HtmlEnumValue(Value = "reversed")]
        Reversed,
        [HtmlEnumValue(Value = "number")]
        Number,
        [HtmlEnumValue(Value = "reversed number")]
        ReversedNumber,
        [HtmlEnumValue(Value = "number reversed")]
        NunberReversed
    }
}