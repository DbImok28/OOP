using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    /*
        Подготовить Спортзал. Снарядов должно быть фиксированное количество в пределах выделенной суммы денег. 
        Провести сортировку инвентаря в Спортзале по одному из параметров. Найти снаряды, соответствующие заданному диапазону цены.
    */
    public class Gym
    {
        public List<Inventory> Inventories { get; private set; }
        public int Budget { get; set; }
        private int priceAllInventory = 0;

        public Gym(int budget)
        {
            Budget = budget;
            Inventories = new List<Inventory>();
        }

        public bool Buy(Inventory item)
        {
            if(priceAllInventory + item.Price > Budget)
            {
                return false;
            }
            priceAllInventory += item.Price;
            Inventories.Add(item);
            return true;
        }
        public void Sale(Inventory item)
        {
            priceAllInventory -= item.Price;
            Inventories.Remove(item);
        }
        public void SortByPrice()
        {
            Inventories.Sort();
        }
        public void Print()
        {
            Console.WriteLine("Gym inventories:");
            foreach (var item in Inventories)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
