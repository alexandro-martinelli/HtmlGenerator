using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class OptionGroups : List<OptionGroup>
    {
        public OptionGroup AddGroup()
        {
            OptionGroup lGroup = new OptionGroup();
            Add(lGroup);
            return lGroup;
        }
    }
}