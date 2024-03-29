﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    [Serializable]
    public class ShopSection
    {
        public LocString Name { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public ShopSection()
        {
            Name = new LocString();
            Icon = "None";
            Products = new ObservableCollection<Product>();
        }
        public ShopSection(LocString name, string icon, ObservableCollection<Product> products)
        {
            Name = name;
            Icon = icon;
            Products = products;
        }
    }
}
