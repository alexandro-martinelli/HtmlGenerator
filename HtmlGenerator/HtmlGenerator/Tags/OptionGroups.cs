using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class OptionGroups : List<OptionGroup>
    {
        public OptionGroup AddGroup(int pId, string pText)
        {
            OptionGroup lGroup = AddGroup();
            lGroup.Id = pId;
            lGroup.Text = pText;
            return lGroup;
        }

        public OptionGroup AddGroup()
        {
            OptionGroup lGroup = new OptionGroup();
            Add(lGroup);
            return lGroup;
        }
    }
}