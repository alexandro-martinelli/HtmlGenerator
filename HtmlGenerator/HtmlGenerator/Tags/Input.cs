using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    [HtmlTag(Name = "input")]
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

        [HtmlNoValueAttribute]
        public bool AutoFocus { get; set; }
        [HtmlAttribute]
        public Usage AutoComplete { get; set; }
        [HtmlNoValueAttribute]
        public bool ReadOnly { get; set; }
        [HtmlNoValueAttribute]
        public bool Required { get; set; }
        [HtmlAttribute]
        public string Value { get; set; }
    }
}
