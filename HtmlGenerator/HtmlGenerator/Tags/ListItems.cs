using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class ListItems : List<ListItem>
    {
        public ListItem AddItem()
        {
            ListItem lItem = new ListItem();
            Add(lItem);
            return lItem;
        }
        
    }
}