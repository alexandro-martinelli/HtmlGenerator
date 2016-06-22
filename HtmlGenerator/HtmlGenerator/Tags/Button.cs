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
        }

        public Button(ButtonType pType) : base()
        {
            Type = pType;
        }

        public ButtonType Type { get; set; }
        public FormOptions FormOptions { get; }


    }
}
