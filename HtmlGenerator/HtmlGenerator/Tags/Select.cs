
using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    [HtmlTag]
    public class Select : HtmlTag
    {
        public Select()
        {
            Groups = new OptionGroups();
        }

        [HtmlItems]
        public OptionGroups Groups { get; private set; }
    }


}
