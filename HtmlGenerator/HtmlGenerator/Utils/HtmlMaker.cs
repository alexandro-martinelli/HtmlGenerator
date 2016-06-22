using HtmlGenerator.Commons;

namespace HtmlGenerator.Utils
{
    public static class HtmlMaker
    {
        public static T MakeTag<T>(Proc<T> pMaker) where T : HtmlTag, new()
        {
            T lHtmlTag = new T();
            pMaker(lHtmlTag);
            return lHtmlTag;
        }

    }
}
