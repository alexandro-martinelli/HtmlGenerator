using HtmlGenerator.Commons;
using HtmlGenerator.Attributes;
using HtmlGenerator.Enums;

namespace HtmlGenerator.TableTags
{

    public abstract class TableCell : HtmlTextContainer
    {
        public TableCell() : base()
        {
            Sort = CellSort.NoSort;
            Scope = CellScope.NoScope;
        }

        [HtmlAttribute(Name = "abbr")]
        public string AbreviatedVersion { get; set; }
        [HtmlAttribute(Name = "colspan")]
        public int ColumnSpan { get; set; }
        [HtmlAttribute]
        public int RowSpan { get; set; }
        [HtmlAttribute]
        public string Headers { get; set; }
        [HtmlAttribute(Name = "sorted")]
        public CellSort Sort { get; set; }
        [HtmlAttribute]
        public CellScope Scope { get; set; }
    }
}