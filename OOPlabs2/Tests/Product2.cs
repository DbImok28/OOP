using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [Serializable]
    public class Product2
    {
        public Product2(LocString name, LocString fullName, int price, string image, LocString description, LocString country)
        {
            Name = name;
            FullName = fullName;
            Price = price;
            Image = image;
            Description = description;
            Country = country;
        }
        public Product2()
        {
            Name = new LocString();
            FullName = new LocString();
            Price = -1;
            Image = "";
            Description = new LocString();
            Country = new LocString();
        }
        public Product2(Product p1, Product p2)
        {
            Name = new LocString(p1.Name, p2.Name);
            FullName = new LocString(p1.FullName, p2.FullName);
            Description = new LocString(p1.Description, p2.Description);
            Country = new LocString(p1.Country, p2.Country);
            Price = p1.Price;
            Image = p1.Image;
        }

        public LocString Name { get; set; }
        public LocString FullName { get; set; }
        public LocString Description { get; set; }
        public LocString Country { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
