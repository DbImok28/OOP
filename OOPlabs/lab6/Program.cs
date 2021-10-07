using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        /*
           4) Определить управляющий класс-Контроллер, который управляет объектом- Контейнером и реализовать в нем запросы по варианту. При необходимости используйте стандартные интерфейсы (IComparable, ICloneable,….)
                 
        */
        static void Main(string[] args)
        {
            Gym gym = new Gym(200);

            gym.Buy(new Bars());
            gym.Buy(new Mats());
            gym.Buy(new Mats());
            gym.Buy(new Ball());
            gym.Buy(new Basketball());
            gym.Buy(new Bench());
            gym.Buy(new Bench()); // no

            gym.Print();

            GymController gymController = new GymController(gym);
            gymController.GetInventoriesByPrice(50).ForEach(i => Console.WriteLine(i.Price));

            Console.ReadKey();
        }
    }
}
