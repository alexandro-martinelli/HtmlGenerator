using HtmlGenerator.Attributes;

namespace HtmlGenerator.TableTags
{
    [HtmlTag(Name = "thead")]
    public class TableHead : TableRows<TableHeadCell>
    {

    }
}
