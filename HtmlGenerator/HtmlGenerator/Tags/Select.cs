
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class Select : HtmlTag
    {
        public Select()
        {
            Options = new Options();
        }

        public Options Options { get; private set; }
        public OptionGroups Groups { get; private set; }
    }


}
