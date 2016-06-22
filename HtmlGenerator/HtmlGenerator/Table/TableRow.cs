using System.Collections.Generic;

namespace HtmlGenerator.Table
{
    public abstract class TableRow<T> : List<T> where T : TableCell, new()
    {
        public T AddCell()
        {
            T lCell = new T();
            return lCell;
        }
    }
}
