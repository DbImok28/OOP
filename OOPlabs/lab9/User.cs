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
        public delegate void UpgradeAllHandler();
        public delegate void WorkHandler();

        public event UpgradeAllHandler OnUpgradeAll;
        public event WorkHandler OnWork;
    }
}
