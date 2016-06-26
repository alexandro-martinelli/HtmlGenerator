using System;

namespace HtmlGenerator.StringGenerator
{
    public class TableHeadStringGenerator : TableCellStringGenerator
    {
        protected override string GetHtmlTagName()
        {
            return "th";
        }
    }
}
