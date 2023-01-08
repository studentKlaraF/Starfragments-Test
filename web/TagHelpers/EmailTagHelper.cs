using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SeminarskaNaloga.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string naslov { get; set; }
        public string vsebina { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + naslov);
            output.Content.SetContent(vsebina);
        }
    }
}