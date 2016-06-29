using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    [HtmlTag]
    public class Button : HtmlTextContainer
    {

        private void InitializeProperties()
        {
            if (FormOptions == null)
            {
                FormOptions = new FormOptions();
            }
            AutoFocus = false;
        }
        public Button()
        {
            Type = ButtonType.Button;
            InitializeProperties();
        }

        public Button(ButtonType pType) : base()
        {
            Type = pType;
            InitializeProperties();
        }
        [HtmlBoolAttribute(InsertIfValue = true, TrueValue = "true")]
        public bool AutoFocus { get; set; }
        [HtmlAttribute(Name = "type")]
        public ButtonType Type { get; set; }
        [HtmlTaged]
        public FormOptions FormOptions { get; private set; }


    }
}
