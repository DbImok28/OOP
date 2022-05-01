using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Tests
{
    [Serializable]
    public class Products2
    {
        public LocString Name { get; set; }
        public string Icon { get; set; }
        public ObservableCollection<Product2> Products { get; set; }
        public Products2()
        {
            Name = new LocString();
            Icon = "None";
            Products = new ObservableCollection<Product2>();
        }
        public Products2(LocString name, string icon, ObservableCollection<Product2> products)
        {
            Name = name;
            Icon = icon;
            Products = products;
        }
        public Products2(ShopSection p1, ShopSection p2)
        {
            Name = new LocString(p1.Name, p2.Name);
            Icon = p1.Icon;
            Products = new ObservableCollection<Product2>();
            for (int i = 0; i < p1.Products.Count; i++)
            {
                Products.Add(new Product2(p1.Products[i], p2.Products[i]));
            }
        }
    }
}
