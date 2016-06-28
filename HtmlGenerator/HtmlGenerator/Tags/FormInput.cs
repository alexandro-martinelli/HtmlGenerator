using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;
using HtmlGenerator.Attributes;

namespace HtmlGenerator.Tags
{
    public abstract class FormInput : Input
    {
        [HtmlTagedAttribute]
        public FormOptions FormOptions { get; set; }
    }

}
