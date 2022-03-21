using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class ApartmentController
    {
        public ApartmentController(IDataController dataController)
        {
            data = dataController;
            director = new ApartmentDirector(new ModernApartmentBuilder());
        }
        public Apartment Add(int footage, int numberOfRooms, int yearOfConstruction, string typeOfMaterial, int floor, Address addressOfRoom)
        {
                var apartment = director.GetApartment(footage, numberOfRooms, yearOfConstruction, typeOfMaterial, floor, addressOfRoom);
                data.AddApartment(apartment);
            OnNewApartment?.Invoke(this, apartment);
            return apartment;
        }

        public void Save()
        {
            data.Save();
        }

        public void Load()
        {
            data.Load();
        }
        public IDataController data { get; private set; }
        public ApartmentDirector director { get; private set; }

        public event EventHandler<Apartment> OnNewApartment;
    }
}
