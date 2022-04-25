using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.Models
{
    [Serializable]
    public class LocString
    {
        public static bool IsSelectedRuLan = true;
        public string Current { get => ToString(); }
        public LocString(string ruString, string enString)
        {
            RuString = ruString;
            EnString = enString;
        }
        public LocString()
        {
            RuString = "";
            EnString = "";
        }
        public override string ToString()
        {
            if (IsSelectedRuLan)
            {
                return RuString;
            }
            else
            {
                return EnString;
            }
        }
        public string RuString { get; set; }
        public string EnString { get; set; }
    }
}
