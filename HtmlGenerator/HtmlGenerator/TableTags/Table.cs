using HtmlGenerator.Commons;
using HtmlGenerator.Attributes;

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
        public TableHead Head { get; set; }
        public TableBody Body { get; set; }
        public TableFooter Footer { get; set; }
    }


    //continuar mapeando as Tags apartir da tabela

}
