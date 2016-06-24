using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public abstract class CheckInput : Input
    {
        public CheckInput(InputType pType)
            : base(pType)
        {

        }

        public bool Checked { get; set; }
    }

}
