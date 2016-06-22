
namespace HtmlGenerator.Utils

{
    public static class Consts
    {
        private const string BeginTag = "<";
        private const string EndTag = ">";
        private const string CloseTag = "/";
        private const string BeginCloseTag = "/>";

        public static string EncapsuleBeginTag(string pTag)
        {
            return BeginTag + pTag + CloseTag;
        }

    }
}
