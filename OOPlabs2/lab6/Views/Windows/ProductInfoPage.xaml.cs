using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab6.Views.Windows
{
    /// <summary>
    /// Interaction logic for ProductInfoPage.xaml
    /// </summary>
    public partial class ProductInfoPage : Page
    {
        public ProductInfoPage(INotifyPropertyChanged baseVM, ICommand goHome)
        {
            InitializeComponent();
            DataContext = baseVM;
            GoHome = goHome;
        }

        private readonly ICommand GoHome;

        private void Go_Home(object sender, RoutedEventArgs e)
        {
            GoHome.Execute(this);
        }
    }
}
