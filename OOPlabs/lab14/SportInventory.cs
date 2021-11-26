using System;

namespace lab5
{
    [Serializable]
    public abstract class SportInventory : Inventory
    {
        public string Name { get; set; }
    }
}
