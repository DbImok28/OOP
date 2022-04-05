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
        public Product(string name, string fullName, int price, string image)
        {
            Name = name;
            FullName = fullName;
            Price = price;
            Image = image;
        }
        public Product()
        {
            Name = "None";
            FullName = "None";
            Price = -1;
            Image = "None";
        }

        public string Name { get; set; }
        public string FullName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}
