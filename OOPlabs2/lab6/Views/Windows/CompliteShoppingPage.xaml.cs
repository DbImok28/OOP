﻿using lab6.Models;
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
    /// Interaction logic for CompliteShopingPage.xaml
    /// </summary>
    public partial class CompliteShopingPage : Page
    {
        public CompliteShopingPage(INotifyPropertyChanged baseVM, ICommand removeProduct, ICommand clear)
        {
            InitializeComponent();
            DataContext = baseVM;
            RemoveProduct = removeProduct;
            Clear = clear;
            Resources.MergedDictionaries.Add(App.CurrentLanguageDictionary);
            App.UpdateLanguage += (o, e) => Resources.MergedDictionaries.Add(e);
            Resources.MergedDictionaries.Add(App.CurrentThemeDictionary);
            App.UpdateTheme += (o, e) => Resources.MergedDictionaries.Add(e);
        }

        public ICommand RemoveProduct { get; }
        public ICommand Clear { get; }

        private void ListBox_RemoveProduct(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as ListBox).SelectedItem as Product;
            RemoveProduct.Execute(product);
        }

        private void ButtonEndShoping_Click(object sender, RoutedEventArgs e)
        {
            Clear.Execute(null);
            MessageBox.Show("Спасибо за покупку", "Спасибо");
        }
    }
}
