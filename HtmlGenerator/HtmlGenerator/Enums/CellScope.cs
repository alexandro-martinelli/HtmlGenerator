using HtmlGenerator.Attributes;

namespace HtmlGenerator.Enums
{
    public enum CellScope
    {
        [HtmlEnumValue]
        NoScope,
        [HtmlEnumValue(Value = "col")]
        Column,
        [HtmlEnumValue(Value = "colgroup")]
        ColumnGroup,
        [HtmlEnumValue(Value = "row")]
        Row,
        [HtmlEnumValue(Value = "rowgroup")]
        RowGroup
    }
}
