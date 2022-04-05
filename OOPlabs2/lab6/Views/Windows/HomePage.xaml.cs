using lab6.Models;
using lab6.ViewModules;
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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(INotifyPropertyChanged baseVM, ICommand showSelectProduct)
        {
            InitializeComponent();
            DataContext = baseVM;
            this.showSelectProduct = showSelectProduct;
        }
        private readonly ICommand showSelectProduct;
        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as ListBox).SelectedItem as Product;
            showSelectProduct.Execute(product);
        }

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (!(e.Item is Product product) || product is null) return;
            var filterText = FilterBox.Text;
            //if (product.Name.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;
            if (product.Name.Contains(filterText)) return;
            e.Accepted = false;
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            var collection = box.FindResource("ProductsGroups") as CollectionViewSource;
            collection.View.Refresh();
        }
    }
}
