using System.Collections.Generic;

namespace HtmlGenerator.Commons
{
    public class HtmlContainer : HtmlTag
    {
        public HtmlContainer() : base()
        {
            Items = new HtmlItems();
        }

        public HtmlItems Items { get; private set; }
    }
}
