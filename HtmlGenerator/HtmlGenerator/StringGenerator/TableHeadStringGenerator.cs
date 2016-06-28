using System;

namespace HtmlGenerator.StringGenerator
{
    public class TableHeadCellStringGenerator : TableCellStringGenerator
    {
        protected override string GetHtmlTagName()
        {
            return "th";
        }
    }
}
