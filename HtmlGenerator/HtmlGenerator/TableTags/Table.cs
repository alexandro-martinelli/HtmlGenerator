using HtmlGenerator.Commons;
using HtmlGenerator.Attributes;
using HtmlGenerator.Enums;

namespace HtmlGenerator.TableTags
{
    [HtmlTag]
    public class Table : HtmlTag
    {
        public Table()
        {
            Head = new TableHead();
            Footer = new TableFooter();
            Body = new TableBody();
        }

        [HtmlTag]
        public bool Sorteable { get; set; }
        [HtmlTag]
        public bool Border { get; set; }
        [HtmlTaged(Location = TagedLocation.Text)]
        public TableHead Head { get; private set; }
        [HtmlTaged(Location = TagedLocation.Text)]
        public TableBody Body { get; private set; }
        [HtmlTaged(Location = TagedLocation.Text)]
        public TableFooter Footer { get; private set; }
    }
}
