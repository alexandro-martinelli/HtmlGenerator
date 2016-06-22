using HtmlGenerator.Utils;
using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class ListOptions : List<ListOption>
    {

        public bool SelectFirstIfNoSelected { get; set; }

        public void AddOption(string pValue, string pText, bool pSelected)
        {
            ListOption lItem = new ListOption();
            lItem.Value = pValue;
            lItem.Selected = pSelected;
            lItem.Text = pText;
            AddAndSelectOption(pSelected, lItem);
        }

        private void AddAndSelectOption(bool pSelected, ListOption pItem)
        {
            Add(pItem);
            if (pSelected)
            {
                UnselectedOthers(pItem);
            }
        }

        public ListOption AddOption(Proc<ListOption> pMaker)
        {
            var lOption = new ListOption();
            pMaker(lOption);
            AddAndSelectOption(lOption.Selected, lOption);
            return lOption;
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
