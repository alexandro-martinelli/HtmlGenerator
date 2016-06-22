using HtmlGenerator.Commons;

namespace HtmlGenerator.Utils
{
    public static class HtmlMaker
    {
        public static T MakeTag<T>(Proc<T> pPopulator) where T : HtmlTag, new()
        {
            T lHtmlTag = new T();
            pPopulator(lHtmlTag);
            return lHtmlTag;
        }

    }
}
