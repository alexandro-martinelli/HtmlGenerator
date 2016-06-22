using HtmlGenerator.Enums;

namespace HtmlGenerator.Commons
{
    public abstract class HtmlTag
    {
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
    }
}
