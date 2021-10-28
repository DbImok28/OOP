using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            PO po1 = new PO(user, "Game");
            PO po2 = new PO(user, "TextEditor");
            PO po3 = new PO(user, "Browser");

            user.UpgradeAllPO();
            user.WorkWithPO();

            string str = "hEllo!";
            str = str.RemoveIf(x => x == '!');
            str = str.AddSymbol(x => 
                {
                    if (x == 'o')
                    {
                        return '?';
                    }
                    else
                    {
                        return null;
                    }
                    //return x == 'o' ? '?' : null;
                }
            );
            str = str.ToUpperIf(x => x == 'h');
            str = str.ToLowerIf(x => x == 'E');
            str.IsHaveSymbol('e', () => { Console.WriteLine("have 'e'!"); });

            Console.WriteLine(str);
            Console.ReadKey();
        }
    }
}
