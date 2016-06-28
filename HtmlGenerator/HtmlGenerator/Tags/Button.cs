using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    [HtmlTag]
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
        [HtmlAttribute]
        public bool AutoFocus { get; set; }
        [HtmlAttribute(Name = "type")]
        public ButtonType Type { get; set; }
        [HtmlTaged]
        public FormOptions FormOptions { get; }


    }
}
