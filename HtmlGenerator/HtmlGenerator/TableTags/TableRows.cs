using System.Collections.Generic;

namespace HtmlGenerator.TableTags
{
    public class TableRows<T> : List<TableRow<T>> where T : TableCell, new()
    {
        public TableRow<T> AddRow()
        {
            TableRow<T> lRow = new TableRow<T>();
            Add(lRow);
            return lRow;
        }
    }
}
