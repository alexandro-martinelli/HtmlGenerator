using HtmlGenerator.Attributes;
using HtmlGenerator.Commons;
using System.Collections.Generic;

namespace HtmlGenerator.Tags
{
    [HtmlTag(Name = "optgroup")]
    public class OptionGroup
    {
        public OptionGroup()
        {
            Options = new Options();
        }

        public Option AddOption()
        {
            Option lOption = new Option();
            Options.Add(lOption);
            return lOption;
        }

        [HtmlAttribute]
        public string Label { get; set; }
        [HtmlItems]
        public Options Options { get; private set; }
    }
}