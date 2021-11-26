using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class JPGLog
    {
        public static void Log(string msg)
        {
            using (var f = new StreamWriter("jpglogfile.txt", true))
            {
                f.Write(msg);
                f.Write(" - ");
                f.WriteLine(DateTime.Now);
            }
        }
        public static string GetByTime(DateTime findTime)
        {
            using (var f = new StreamReader("jpglogfile.txt"))
            {
                while (!f.EndOfStream)
                {
                    string str = f.ReadLine();
                    string date = str.Substring(str.IndexOf('-') + 1);

                    var time = DateTime.Parse(date);
                    if (findTime == time)
                    {
                        //string msg = str.Substring(0, str.IndexOf('-') - 1);
                        return str;
                    }
                }
            }
            return "";
        }
        public static string GetByMessage(string msg)
        {
            using (var f = new StreamReader("jpglogfile.txt"))
            {
                while (!f.EndOfStream)
                {
                    string str = f.ReadLine();
                    string pmsg = str.Substring(0, str.IndexOf('-') - 1);
                    string date = str.Substring(str.IndexOf('-') + 1);

                    var time = DateTime.Parse(date);
                    if (msg == pmsg)
                    {
                        return str;
                    }
                }
            }
            return "";
        }
    }
}
