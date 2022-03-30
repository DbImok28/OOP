using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    public class NavigationItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public NavigationItem(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }
    }
}
