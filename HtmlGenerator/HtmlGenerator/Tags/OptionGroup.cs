using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class OptionGroup
    {
        public OptionGroup()
        {

        }

        public OptionGroup(int pId, string pText)
        {
            Id = pId;
            Text = pText;
        }

        public int Id { get; set; }
        public string Text { get; set; }
    }
}