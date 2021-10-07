using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    public class GymController
    {
        public Gym gym;
        public GymController(Gym gym)
        {
            if (gym is null)
            {
                throw new ArgumentNullException(nameof(gym));
            }

            this.gym = gym;
        }
        public List<Inventory> GetInventoriesByPrice(int maxPrice)
        {
            List<Inventory> result = new List<Inventory>();

            foreach (var item in gym.Inventories)
            {
                if (item.Price <= maxPrice)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
