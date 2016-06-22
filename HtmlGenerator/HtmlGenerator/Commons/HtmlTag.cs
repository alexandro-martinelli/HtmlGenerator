using HtmlGenerator.Enums;
using System.Collections.Generic;

namespace HtmlGenerator.Commons
{
    public abstract class HtmlTag
    {
        public HtmlTag()
        {
            AnotherAttributes = new List<object>();
            AutoComplete = Usage.Default;
            ReadOnly = false;
            Required = false;
        }

        public bool AutoFocus { get; set; }
        public string Id { get; set; }
        public Usage AutoComplete { get; set; }
        public bool Disabled { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string PlaceHolder { get; set; }
        public bool ReadOnly { get; set; }
        public bool Required { get; set; }
        public int Size { get; set; }
        public int MaximunLength { get; set; }
        public string Value { get; set; }
        public string Class { get; set; }
        public List<object> AnotherAttributes { get; private set; }
    }
}
