using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.Models
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Speciality { get; set; }
        public string Categories { get; set; }
        public string Department { get; set; }
        public byte[] Photo { get; set; }
    }
}
