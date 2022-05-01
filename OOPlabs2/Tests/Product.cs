using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [Serializable]
    public class Product
    {
        public Product(string name, string fullName, int price, string image, string description, string country)
        {
            Name = name;
            FullName = fullName;
            Price = price;
            Image = image;
            Description = description;
            Country = country;
        }
        public Product()
        {
            Name = "";
            FullName = "";
            Price = -1;
            Image = "";
            Description = "";
            Country = "";
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
