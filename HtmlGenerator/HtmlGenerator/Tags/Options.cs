using HtmlGenerator.Utils;
using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    public class Options : List<Option>
    {
        public bool SelectFirstIfNoSelected { get; set; }

        public void AddOption(string pValue, string pText, bool pSelected)
        {
            Option lItem = new Option();
            lItem.Value = pValue;
            lItem.Selected = pSelected;
            lItem.Text = pText;
            AddAndSelectOption(pSelected, lItem);
        }

        private void AddAndSelectOption(bool pSelected, Option pItem)
        {
            Add(pItem);
            if (pSelected)
            {
                UnselectedOthers(pItem);
            }
        }

        public Option AddOption(Proc<Option> pMaker)
        {
            var lOption = new Option();
            pMaker(lOption);
            AddAndSelectOption(lOption.Selected, lOption);
            return lOption;
        }

        private void UnselectedOthers(Option pItem)
        {
            foreach (Option lItem in this)
            {
                lItem.Selected = (lItem == pItem);
            }
        }
    }
}
