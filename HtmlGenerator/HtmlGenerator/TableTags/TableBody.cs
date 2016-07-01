using HtmlGenerator.Attributes;

namespace HtmlGenerator.TableTags
{
    [HtmlTag(Name = "tbody")]
    public class TableBody : TableRows<TableBodyCell>
    {

    }
}
