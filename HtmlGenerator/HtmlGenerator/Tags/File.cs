using HtmlGenerator.Enums;
using HtmlGenerator.Commons;

namespace HtmlGenerator.Tags
{
    public class File : Input
    {
        public File() : base()
        {
            FileOptions = new FileOptions();
        }

        protected override InputType GetInputType()
        {
            return InputType.File;
        }

        public FileOptions FileOptions { get; private set; }
    }
}
