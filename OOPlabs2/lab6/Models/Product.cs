using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    [Serializable]
    public class Product
    {
        public Product(LocString name, LocString fullName, int price, string image, LocString description, LocString country)
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
            Name = new LocString();
            FullName = new LocString();
            Price = -1;
            Image = "";
            Description = new LocString();
            Country = new LocString();
        }

        public LocString Name { get; set; }
        public LocString FullName { get; set; }
        public LocString Description { get; set; }
        public LocString Country { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
