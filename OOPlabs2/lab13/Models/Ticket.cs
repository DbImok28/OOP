using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public int DoctorID { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Time { get; set; }
        public int Number { get; set; } = 0;
    }
}
