using HtmlGenerator.Attributes;

namespace HtmlGenerator.Commons
{
    public class HtmlContainer : HtmlTag
    {
        public HtmlContainer() : base()
        {
            Items = new HtmlItems();
        }
        [HtmlItems]
        public HtmlItems Items { get; private set; }
    }
}
