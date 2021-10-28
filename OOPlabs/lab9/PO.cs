using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class PO
    {
        public PO(User user, string name)
        {
            Name = name;
            version = new Version(1,0);
            user.OnUpgradeAll += () =>
            {
                version = new Version(version.Major, version.Minor + 1);
            };
            user.OnWork += () =>
            {
                Console.WriteLine($"Work: {Name}, Version: {version}");
            };
        }

        Version version;
        string Name;
    }
}
