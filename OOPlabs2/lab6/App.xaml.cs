using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace lab6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static void ChangeLanguage(string newLang)
        {
            CurrentLanguage = newLang;
            CurrentLanguageDictionary.Source = new Uri($"..\\Resources\\TextLocalization.{newLang}.xaml", UriKind.Relative);
            UpdateLanguage?.Invoke(null, CurrentLanguageDictionary);
        }
        public static ResourceDictionary CurrentLanguageDictionary { get; private set; } = new ResourceDictionary();
        public static event EventHandler<ResourceDictionary> UpdateLanguage;
        public static string CurrentLanguage { get; private set; } = "ru";

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ChangeLanguage(CurrentLanguage);
        }
    }
}
