using System;

namespace lab6
{
    public abstract class Inventory : IComparable
    {
        public abstract void Use();

        public int CompareTo(object obj)
        {
            if (obj is Inventory item)
            {
                return Price.CompareTo(item.Price);
            }
            else
            {
                throw new ArgumentException("obj is not Inventory");
            }
        }

        public int Price = 10;
    }
}
