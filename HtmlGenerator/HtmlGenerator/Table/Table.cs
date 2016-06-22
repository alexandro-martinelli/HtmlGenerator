using HtmlGenerator.Commons;

namespace HtmlGenerator.Table
{
    public class Table : HtmlContainer
    {
        public bool Sorteable { get; set; }
        public bool Border { get; set; }
        public TableHead Head { get; set; }
        public TableBody Body { get; set; }
        public TableFooter Footer { get; set; }
    }


}
