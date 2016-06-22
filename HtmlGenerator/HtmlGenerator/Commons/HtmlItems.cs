using HtmlGenerator.Utils;
using System.Collections.Generic;

namespace HtmlGenerator.Commons
{
    public class HtmlItems : List<HtmlTag>
    {
        public T AddItem<T>(Proc<T> pPopulator) where T : HtmlTag, new()
        {
            T lTag = new T();
            if (pPopulator != null)
            {
                pPopulator(lTag);
            }
            Add(lTag);
            return lTag;
        }

        public T AddItem<T>() where T : HtmlTag, new()
        {
            return AddItem<T>(null);
        }

    }
}
