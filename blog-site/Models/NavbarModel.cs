using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class NavbarModel
    {
        public List<NavbarItem> Items { get; set; }
    }

    public class NavbarItem
    {
        public string Label { get; set; }

        public string Url { get; set; }
    }
}