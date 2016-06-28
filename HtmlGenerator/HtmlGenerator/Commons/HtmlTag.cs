using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;
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
        }
        [HtmlAttribute]
        public string AccessKey { get; set; }
        [HtmlAttribute]
        public string Id { get; set; }
        [HtmlAttribute]
        public Usage ContentEditable { get; set; }
        [HtmlNoValueAttribute]
        public bool Disabled { get; set; }
        [HtmlAttribute]
        public string Name { get; set; }
        [HtmlAttribute]
        public string Pattern { get; set; }
        [HtmlAttribute]
        public string PlaceHolder { get; set; }
        [HtmlNoValueAttribute]
        public bool Hidden { get; set; }
        [HtmlAttribute]
        public string Class { get; set; }
        [HtmlBoolAttribute(InsertIfValue = false, FalseValue = "no")]
        public bool Translate { get; set; }
        [HtmlAttribute]
        public int TabIndex { get; set; }
        [HtmlAttribute]
        public string Title { get; set; }
        [HtmlAttribute]
        public Direction Direction { get; set; }
        [HtmlAttribute]
        public string Style { get; set; }
        [HtmlAnonymousAttribute]
        public List<object> AnotherAttributes { get; private set; }
    }
}
