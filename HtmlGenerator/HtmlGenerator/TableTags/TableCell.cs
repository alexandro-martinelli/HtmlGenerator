using HtmlGenerator.Commons;

namespace HtmlGenerator.TableTags
{

    public abstract class TableCell : HtmlTextContainer
    {
        public int CollumnSpan { get; set; }
        public int RowSpan { get; set; }
        public string Headers { get; set; }
    }
}