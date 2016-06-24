using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public class Input : HtmlTag
    {
        private InputType FType;

        public Input(InputType pType)
        {
            FType = pType;
        }

        public InputType Type { get { return FType; } }

        //Listered Input
        public string ListName { get; set; }
        public Options ListData { get; set; }
        
        //File
        public FileOptions FileOptions { get; set; }

        // Image
        public string Source { get; set; }
        public int Height { get; set; }
        public double Width { get; set; }
        public string AlternateText { get; set; }

        // Submit and Image
        public FormOptions FormOptions { get; set; }        

    }



}
