﻿using lab6.Models;
using lab6.Views.Windows;
using System;
using System.Collections.Generic;
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

namespace lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Resources.MergedDictionaries.Add(App.CurrentLanguageDictionary);
            App.UpdateLanguage += (o,e) => Resources.MergedDictionaries.Add(e);
            Resources.MergedDictionaries.Add(App.CurrentThemeDictionary);
            App.UpdateTheme += (o, e) => Resources.MergedDictionaries.Add(e);
        }
        static MainWindow()
        {
            Exit = new RoutedCommand("Exit", typeof(MainWindow));
        }
        public static RoutedCommand Exit { get; set; }
        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}
