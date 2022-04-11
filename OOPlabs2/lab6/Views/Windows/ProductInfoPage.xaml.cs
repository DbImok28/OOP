using lab6.Models;
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
        public ProductInfoPage(INotifyPropertyChanged baseVM, ICommand removeProduct)
        {
            InitializeComponent();
            DataContext = baseVM;
            RemoveProduct = removeProduct;
            Resources.MergedDictionaries.Add(App.CurrentLanguageDictionary);
            App.UpdateLanguage += (o, e) => Resources.MergedDictionaries.Add(e);
        }

        public ICommand RemoveProduct { get; }
        private void ListBox_RemoveProduct(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as ListBox).SelectedItem as Product;
            RemoveProduct.Execute(product);
        }
    }
}
