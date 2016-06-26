using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public abstract class Input : HtmlTag
    {
        public Input()
        {
            ListData = new Options();
            AutoFocus = false;
            AutoComplete = Usage.Default;
            ReadOnly = false;
            Required = false;
        }

        public InputType Type { get { return GetInputType(); } }

        protected abstract InputType GetInputType();

        //Listered Input
        public string ListName { get; set; }
        public Options ListData { get; private set; }

        public bool AutoFocus { get; set; }
        public Usage AutoComplete { get; set; }
        public bool ReadOnly { get; set; }
        public bool Required { get; set; }
        public string Value { get; set; }
    }
}
