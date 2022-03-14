using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class ModernApartmentBuilder : IApartmentBuilder
    {
        public ModernApartmentBuilder()
        {
            apartment = new Apartment();
            apartment.Kitchen = true;
            apartment.Bath = true;
            apartment.Toilet = true;
            apartment.Balcony = true;
        }
        public void BuildKitchen()
        {
            apartment.Kitchen = true;
        }
        public void BuildBath()
        {
            apartment.Bath = true;
        }
        public void BuildToilet()
        {
            apartment.Toilet = true;
        }
        public void BuildBasement()
        {
            apartment.Basement = true;
        }
        public void BuildBalcony()
        {
            apartment.Balcony = true;
        }
        public void BuildRooms(int footage, int numberOfRooms, int yearOfConstruction, string material, int floor, Address address)
        {
            apartment.Footage = footage;
            apartment.NumberOfRooms = numberOfRooms;
            apartment.YearOfConstruction = yearOfConstruction;
            apartment.TypeOfMaterial = material;
            apartment.Floor = floor;
            apartment.AddressOfRoom = address;
        }
        public Apartment GetApartment()
        {
            return apartment;
        }
        public Apartment apartment { get; private set; }
    }
}
