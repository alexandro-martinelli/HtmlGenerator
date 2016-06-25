
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class List : HtmlTag
    {
        public List()
        {
            Items = new ListItems();
            Ordered = false;
        }

        public ListItems Items { get; private set; }
        public bool Ordered { get; set; }

    }
}
