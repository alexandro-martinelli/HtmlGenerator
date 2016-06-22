using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class ListOptions : List<ListOption>
    {

        public bool SelectFirstIfNoSelected { get; set; }

        public void AddItem(string pValue, bool pSelected)
        {
            ListOption lItem = new ListOption();
            lItem.Value = pValue;
            lItem.Selected = pSelected;
            Add(lItem);
            if (pSelected)
            {
                UnselectedOthers(lItem);
            }
        }

        private void UnselectedOthers(ListOption pItem)
        {
            foreach (ListOption lItem in this)
            {
                lItem.Selected = (lItem == pItem);
            }
        }
    }
}
