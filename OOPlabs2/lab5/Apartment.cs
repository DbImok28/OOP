using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    [Serializable]
    public class Apartment
    {
        public Apartment()
        {

        }
        public Apartment(int footage, int numberOfRooms, bool kitchen, bool bath, bool toilet, bool basement,
                         bool balcony, int yearOfConstruction, string typeOfMaterial, int floor, Address addressOfRoom)
        {
            Footage = footage;
            NumberOfRooms = numberOfRooms;
            Kitchen = kitchen;
            Bath = bath;
            Toilet = toilet;
            Basement = basement;
            Balcony = balcony;
            YearOfConstruction = yearOfConstruction;
            TypeOfMaterial = typeOfMaterial;
            Floor = floor;
            AddressOfRoom = addressOfRoom;
        }

        public int Footage { get; set; }
        public int NumberOfRooms { get; set; }
        public bool Kitchen { get; set; }
        public bool Bath { get; set; }
        public bool Toilet { get; set; }
        public bool Basement { get; set; }
        public bool Balcony { get; set; }
        public int YearOfConstruction { get; set; }
        public string TypeOfMaterial { get; set; }
        public int Floor { get; set; }
        public Address AddressOfRoom { get; set; }
    }
}
