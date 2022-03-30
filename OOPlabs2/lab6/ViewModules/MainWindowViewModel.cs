using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab6.ViewModules
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Title
        private string _Title = "Магазин";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        #region Status
        private string _Status = "Фрукты";
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }
        #endregion
        #region NavigationItems
        private ObservableCollection<Models.NavigationItem> _NavigationItems = new ObservableCollection<Models.NavigationItem> {
            new Models.NavigationItem( "Фрукты", "/Resources/fruits.png"), new Models.NavigationItem("Овощи", "/Resources/vegetables.png") 
        };
        public ObservableCollection<Models.NavigationItem> NavigationItems
        {
            get => _NavigationItems;
            set => Set(ref _NavigationItems, value);
        }
        #endregion
        #region Products
        private ObservableCollection<Models.Product> _Products = new ObservableCollection<Models.Product> {
            new Models.Product( "Яблоко","Яблоко дружба", 10, "banana"), new Models.Product( "Лимон","Лимон кислый", 20, "Resources\\fruits.png")
        };
        public ObservableCollection<Models.Product> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
        }
        #endregion
        #region Commands

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecuted(object par) => Application.Current.Shutdown();   
        private bool CanCloseApplicationCommandExecute(object par) => true;
        #endregion
        #endregion

        public MainWindowViewModel()
        {
            #region Commands
            CloseApplicationCommand = new Infrastructure.Commands.LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion
        }
    }
}
