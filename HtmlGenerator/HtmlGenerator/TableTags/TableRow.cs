using System.Collections.Generic;
using HtmlGenerator.Attributes;
using HtmlGenerator.Utils;
using HtmlGenerator.Enums;
using HtmlGenerator.Commons;

namespace HtmlGenerator.TableTags
{
    [HtmlTag(Name = "tr")]
    public class TableRow<T> : HtmlTag where T : TableCell, new()
    {
        public TableRow()
        {
            Cells = new List<T>();
        }

        public T AddCell()
        {
            return AddCell(null);
        }

        public void AddCellForText(string[] pTexts)
        {
            foreach (string lText in pTexts)
            {
                T lCell = AddCell();
                lCell.Text = lText;
            }
        }

        public void AddCellForText(List<string> pTexts)
        {
            AddCellForText(pTexts.ToArray());
        }

        public T AddCell(Proc<T> pPopulator)
        {
            T lCell = new T();
            if (pPopulator != null)
            {
                pPopulator(lCell);
            }
            Cells.Add(lCell);
            return lCell;
        }
        [HtmlItems]
        public List<T> Cells { get; private set; }
    }

}
