using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab6.Infrastructure.Commands
{
    public class CommandSet
    {
        static CommandSet()
        {
            Exit = new RoutedUICommand("Close application", "Exit", typeof(CommandSet));
        }
        public static RoutedCommand Exit { get; set; }
        public static void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        public static void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
