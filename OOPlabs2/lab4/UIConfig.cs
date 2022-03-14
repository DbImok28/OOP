using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    public class UIConfig
    {
        public static UIConfig GetInstance()
        {
            return instance;
        }
        private static UIConfig instance = new UIConfig();
        private UIConfig()
        {

        }
        public Color BGColor { get; set; } = Color.LightGray;
        public Font GridFont { get; set; } = new Font("Tahoma", 15);
        public Color GridBGColor { get; set; } = Color.LightBlue;
    }
}
