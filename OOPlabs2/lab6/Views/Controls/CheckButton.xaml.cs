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

namespace lab6.Views.Controls
{
    /// <summary>
    /// Interaction logic for CheckButton.xaml
    /// </summary>
    public partial class CheckButton : UserControl
    {
        #region Properties
        public string CheckData
        {
            get => (string)GetValue(CheckDataProperty);
            set => SetValue(CheckDataProperty, value);
        }
        public static readonly DependencyProperty CheckDataProperty;

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public static readonly DependencyProperty TextProperty;

        public bool IsShowText
        {
            get => (bool)GetValue(IsShowTextTextProperty);
            set
            {
                SetValue(IsShowTextTextProperty, value);
                CheckDataTextBlock.Visibility = value ? Visibility.Visible : Visibility.Hidden;
            }
        }
        public static readonly DependencyProperty IsShowTextTextProperty;
        #endregion
        #region Events
        // Success
        public static readonly RoutedEvent SuccessEvent;
        public event RoutedEventHandler Success
        {
            add => AddHandler(SuccessEvent, value);
            remove => RemoveHandler(SuccessEvent, value);
        }
        private void RaiseSuccessEvent() => RaiseEvent(new RoutedEventArgs(SuccessEvent));

        // Faill
        public static readonly RoutedEvent FaillEvent;
        public event RoutedEventHandler Faill
        {
            add => AddHandler(FaillEvent, value);
            remove => RemoveHandler(FaillEvent, value);
        }
        private void RaiseFaillEvent() => RaiseEvent(new RoutedEventArgs(FaillEvent));
        #endregion
        static CheckButton()
        {
            var meta = new PropertyMetadata("");
            meta.CoerceValueCallback += CorrectValueIsString;
            TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CheckButton), meta, ValidateValueIsString);
            CheckDataProperty = DependencyProperty.Register("CheckData", typeof(string), typeof(CheckButton), new PropertyMetadata("password"), ValidateValueIsString);
            IsShowTextTextProperty = DependencyProperty.Register("IsShowText", typeof(bool), typeof(CheckButton), new PropertyMetadata(true));

            SuccessEvent = EventManager.RegisterRoutedEvent("Success", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CheckButton));
            FaillEvent = EventManager.RegisterRoutedEvent("Faill", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CheckButton));           
        }

        private static bool ValidateValueIsString(object value)
        {
            return value is string;
        }
        private static object CorrectValueIsString(DependencyObject d, object baseValue)
        {
            return baseValue.ToString();
        }

        public CheckButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputText.Text == CheckData)
            {
                RaiseSuccessEvent();
            }
            else
            {
                RaiseFaillEvent();
            }

        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            InputText.Opacity = 1;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            InputText.Opacity = 0.5;
        }
    }
}
