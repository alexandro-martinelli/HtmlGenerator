using System;
using HtmlGenerator.Commons;
using HtmlGenerator.Enums;

namespace HtmlGenerator.Tags
{
    public abstract class FormInput : Input
    {
        public FormOptions FormOptions { get; set; }
    }

}
