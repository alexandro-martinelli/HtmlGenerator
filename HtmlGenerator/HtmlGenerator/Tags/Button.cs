using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Button : HtmlTextContainer
    {
        public Button(ButtonType pType)
        {
            Type = pType;

        }

        public ButtonType Type { get; private set; }
        public FormOptions FormOptions { get; }


    }
}
