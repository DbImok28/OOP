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
        #region Language
        public static void ChangeLanguage(string newLang)
        {
            CurrentLanguage = newLang;
            CurrentLanguageDictionary.Source = new Uri($"..\\Resources\\TextLocalization.{newLang}.xaml", UriKind.Relative);
            UpdateLanguage?.Invoke(null, CurrentLanguageDictionary);
        }
        public static ResourceDictionary CurrentLanguageDictionary { get; private set; } = new ResourceDictionary();
        public static event EventHandler<ResourceDictionary> UpdateLanguage;
        public static string CurrentLanguage { get; private set; } = "ru";
        #endregion
        #region Theme
        public enum Theme
        {
            Blue, Gray
        }
        public static void ChangeTheme(Theme theme)
        {
            CurrentTheme = theme;
            CurrentThemeDictionary.Source = new Uri($"..\\Resources\\{theme}Theme.xaml", UriKind.Relative);
            UpdateTheme?.Invoke(null, CurrentThemeDictionary);
        }
        public static ResourceDictionary CurrentThemeDictionary { get; private set; } = new ResourceDictionary();
        public static event EventHandler<ResourceDictionary> UpdateTheme;
        public static Theme CurrentTheme { get; private set; } = Theme.Blue;
        #endregion

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ChangeLanguage(CurrentLanguage);
            ChangeTheme(Theme.Blue);
        }
    }
}
