using HtmlGenerator.Commons;

namespace HtmlGenerator.TableTags
{
    public class Table : HtmlTag
    {
        public Table()
        {
            Head = new TableHead();
            Footer = new TableFooter();
            Body = new TableBody();
        }

        public bool Sorteable { get; set; }
        public bool Border { get; set; }
        public TableHead Head { get; set; }
        public TableBody Body { get; set; }
        public TableFooter Footer { get; set; }
    }


}
