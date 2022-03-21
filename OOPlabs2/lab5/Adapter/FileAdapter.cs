using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    public class FileAdapter
    {
        public DataController dataController { get; }

        public FileAdapter(DataController dataController)
        {
            this.dataController = dataController;
        }
        public void Save()
        {
            XMLFileSerializer.SerializeToXML("Apartment.xml", dataController.apartments);
            XMLFileSerializer.SerializeToXML("Address.xml", dataController.addresses);
        }
        public void Load()
        {
            dataController.apartments = XMLFileSerializer.DeserializeXML<List<Apartment>>("Apartment.xml");
            dataController.addresses = XMLFileSerializer.DeserializeXML<List<Address>>("Address.xml");
        }
    }
}
