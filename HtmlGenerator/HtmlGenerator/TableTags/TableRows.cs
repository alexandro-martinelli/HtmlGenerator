using System.Collections.Generic;
using HtmlGenerator.Attributes;
using HtmlGenerator.Utils;
using HtmlGenerator.Enums;

namespace HtmlGenerator.TableTags
{
    public abstract class TableRows<T> where T : TableCell, new()
    {
        public TableRows()
        {
            Rows = new List<TableRow<T>>();
        }

        public TableRow<T> AddRow()
        {
            return AddRow(null);
        }

        public TableRow<T> AddRow(Proc<TableRow<T>> pPopulator)
        {
            TableRow<T> lRow = new TableRow<T>();
            if (pPopulator != null)
            {
                pPopulator(lRow);
            }
            Rows.Add(lRow);
            return lRow;
        }


        [HtmlItems]
        public List<TableRow<T>> Rows { get; private set; }
    }
}
