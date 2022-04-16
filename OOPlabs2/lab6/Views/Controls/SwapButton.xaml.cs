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
    /// Interaction logic for SwapButton.xaml
    /// </summary>
    public partial class SwapButton : UserControl
    {
        public SwapButton()
        {
            InitializeComponent();
            contentPresenter.Content = NotPressedContent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SwapIcons();
            Click?.Invoke(this, e);
        }
        public void SwapIcons()
        {
            if (IsPressed)
            {
                contentPresenter.Content = PressedContent;
            }
            else
            {
                contentPresenter.Content = NotPressedContent;
            }
            IsPressed = !IsPressed;
        }
        public event RoutedEventHandler Click;


        //public bool IsPressed
        //{
        //    get { return (bool)GetValue(IsPressedProperty); }
        //    set { SetValue(IsPressedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IsPressed.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IsPressedProperty =
        //    DependencyProperty.Register("IsPressed", typeof(bool), typeof(SwapButton), new PropertyMetadata(0));
        public object NotPressedContent { get; set; } = new ContentControl();
        public object PressedContent { get; set; } = new ContentControl();

        public bool IsPressed { get; private set; } = true;
    }
}
