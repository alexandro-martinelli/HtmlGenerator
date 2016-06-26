using System;
using HtmlGenerator.Commons;
using HtmlGenerator.TableTags;
using HtmlGenerator.Utils;

namespace HtmlGenerator.StringGenerator
{
    public class TableStringGenerator: HtmlTagStringGenerator
    {
        protected override string ConvertSelfAttributes(HtmlTag pHtmlTag)
        {
            Table lTable = (Table)pHtmlTag;
            string lHtml = "";
            if (lTable.Sorteable)
            {
                lHtml += ConcatOnlyAttribute("sorteable");
            }
            lHtml += ConcatAttributeWithValue("border", lTable.Border ? "1" : "0");
            return lHtml;
        }

        protected override string GetHtmlTagName()
        {
            return "table";
        }

        protected override string ConvertMidleAttributes(HtmlTag pHtmlTag)
        {
            Table lTable = (Table)pHtmlTag;
            MasterStringGenerator lGenerator = new MasterStringGenerator();
            string lHtml = ExtractHtmlHead(lTable, lGenerator);
            lHtml += ExtractHtmlBody(lTable, lGenerator);
            lHtml += ExtractHtmlFooter(lTable, lGenerator);
            return lHtml;
        }

        private string ExtractHtmlHead(Table pTable, MasterStringGenerator pGenerator)
        {
            string lHtmlHead = "";
            foreach (TableHeadCell lCell in pTable.Head)
            {
                lHtmlHead += pGenerator.ToHtmlString(lCell);
            }
            string lHtml = "";
            if (lHtmlHead != "")
            {
                lHtmlHead = HtmlHelper.EnclosureTag("tr", lHtmlHead);
                lHtml = HtmlHelper.EnclosureTag("thead", lHtmlHead);
            }
            return lHtml;
        }

        private string ExtractHtmlBody(Table pTable, MasterStringGenerator pGenerator)
        {
            string lHtml = "";
            string lHtmlRow = "";
            foreach (TableBodyRow lRow in pTable.Body)
            {
                lHtmlRow = "";
                foreach (TableBodyCell lCell in lRow)
                {
                    lHtmlRow += pGenerator.ToHtmlString(lCell);
                }
                if (lHtmlRow != "") {
                    lHtml += HtmlHelper.EnclosureTag("<tr>", lHtmlRow);
                }
            }
            if (lHtml != "")
            {
                lHtml += HtmlHelper.EnclosureTag("tbody", lHtml);
            }
            return lHtml;
        }

        private string ExtractHtmlFooter(Table pTable, MasterStringGenerator pGenerator)
        {
            string lHtmlFooter = "";
            foreach (TableFooterCell lCell in pTable.Footer)
            {
                lHtmlFooter += pGenerator.ToHtmlString(lCell);
            }
            string lHtml = "";
            if (lHtmlFooter != "")
            {
                lHtmlFooter = HtmlHelper.EnclosureTag("tr", lHtmlFooter);
                lHtml = HtmlHelper.EnclosureTag("tfoot", lHtmlFooter);
            }
            return lHtml;
        }

    }

}
