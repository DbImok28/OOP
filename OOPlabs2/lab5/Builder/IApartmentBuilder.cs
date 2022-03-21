using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public interface IApartmentBuilder
    {
        void BuildKitchen();
        void BuildBath();
        void BuildToilet();
        void BuildBasement();
        void BuildBalcony();
        void BuildRooms(int footage, int numberOfRooms, int yearOfConstruction, string material, int floor, Address address);
        Apartment GetApartment();
    }
}
