using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Button : HtmlTextContainer
    {

        public Button()
        {
            Type = ButtonType.Button;
            FormOptions = new FormOptions();
            AutoFocus = false;
        }

        public Button(ButtonType pType) : base()
        {
            Type = pType;
        }

        public bool AutoFocus { get; set; }
        public ButtonType Type { get; set; }
        public FormOptions FormOptions { get; }


    }
}
