using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class User
    {

        public void UpgradeAllPO()
        {
            OnUpgradeAll.Invoke();
        }
        public void WorkWithPO()
        {
            OnWork.Invoke();
        }
        public delegate void Upgrade();
        public delegate void Work();

        public event Upgrade OnUpgradeAll;
        public event Work OnWork;
    }
}
