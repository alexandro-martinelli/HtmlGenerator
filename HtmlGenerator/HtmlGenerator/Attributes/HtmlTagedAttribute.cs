using HtmlGenerator.Enums;
using System;

namespace HtmlGenerator.Attributes
{
    public class HtmlTagedAttribute : Attribute
    {
        public HtmlTagedAttribute()
        {
            Location = TagedLocation.Attributes;
        }

        public TagedLocation Location { get; set; }

    }
}
