using System;
using HtmlGenerator.Commons;
using HtmlGenerator.TableTags;

namespace HtmlGenerator.StringGenerator
{
    public class TableCellStringGenerator : HtmlTextContainerStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            TableCell lCell = (TableCell)pHtmlTag;
            string lHtml = "";
            if (lCell.CollumnSpan > 1)
            {
                lHtml = ConcatAttributeWithValue("colspan", lCell.CollumnSpan.ToString());
            }
            if (lCell.CollumnSpan > 1)
            {
                lHtml += ConcatAttributeWithValue("rowspan", lCell.RowSpan.ToString());
            }
            lHtml += ConcatAttributeWithValue("headers", lCell.Headers);
            return lHtml;
        }

        protected override string GetHtmlTagName()
        {
            return "td";
        }
    }

}
