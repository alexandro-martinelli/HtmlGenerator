using System.Collections.Generic;

namespace HtmlGenerator.TableTags
{
    public class TableBodyRows : List<TableBodyRow>
    {
        public TableBodyRow AddRow()
        {
            TableBodyRow lRow = new TableBodyRow();
            Add(lRow);
            return lRow;
        }
    }
}
