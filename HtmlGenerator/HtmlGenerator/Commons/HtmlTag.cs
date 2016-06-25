using HtmlGenerator.Enums;
using System.Collections.Generic;

namespace HtmlGenerator.Commons
{
    public abstract class HtmlTag
    {
        public HtmlTag()
        {
            AnotherAttributes = new List<object>();
            Direction = Direction.LeftToRight;
            Translate = true;
            ContentEditable = Usage.Default;

            //AutoComplete = Usage.Default;
            //ReadOnly = false;
            //Required = false;
        }

        public string AccessKey { get; set; }
        public string Id { get; set; }
        public Usage ContentEditable { get; set; }
        public bool Disabled { get; set; }
        public string Name { get; set; }
        public string Pattern { get; set; }
        public string PlaceHolder { get; set; }
        public bool Hidden { get; set; }
        public string Class { get; set; }
        public bool Translate { get; set; }
        public int TabIndex { get; set; }
        public string Title { get; set; }
        public Direction Direction { get; set; }
        public string Style { get; set; }
        public List<object> AnotherAttributes { get; private set; }

        //public bool AutoFocus { get; set; }
        //public Usage AutoComplete { get; set; }
        //public bool ReadOnly { get; set; }
        //public bool Required { get; set; }
        //public int Size { get; set; }
        //public int MaximunLength { get; set; }
        //public string Value { get; set; }

    }
}
