using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инвентарь, Скамейка, Брусья, Мяч,  Маты, Баскетбольный мяч,  Теннис.
            // Inventory, Bench,    Bars,   Ball, Mats, Basketball,         Tennis.

            Ball ball = new Ball();
            Basketball basketball = new Basketball();
            Mats mat = new Mats();
            Bench bench = new Bench();
            Tennis tennis = new Tennis(basketball);

            SportGame game = tennis;
            game.Play();

            IHit hit = ball;
            hit.Hit();

            Inventory inventory = bench;
            Console.WriteLine(inventory.ToString());

            if (inventory is Mats)
            {
                inventory.Use();
            }


            Printer printer = new Printer();

            Inventory[] inventories = 
            {
                ball,
                mat,
                bench,
                basketball,
                new Bars()
            };

            foreach (var item in inventories)
            {
                printer.Print(item);
            }
            Console.ReadKey();
        }
    }
}
