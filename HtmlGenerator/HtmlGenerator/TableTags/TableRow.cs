using System.Collections.Generic;

namespace HtmlGenerator.TableTags
{
    public class TableRow<T> : List<T> where T : TableCell, new()
    {
        public TableRow()
        {
            Attributes = new List<object>();
        }

        public T AddCell()
        {
            T lCell = new T();
            Add(lCell);
            return lCell;
        }

        public List<object> Attributes { get; private set; }
    }

}
