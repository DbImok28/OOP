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
        #region ShopSections
        private ObservableCollection<Models.ShopSection> _ShopSections;
        public ObservableCollection<Models.ShopSection> ShopSections
        {
            get => _ShopSections;
            set => Set(ref _ShopSections, value);
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

            ShopSections = new ObservableCollection<Models.ShopSection> {
                new Models.ShopSection(
                    "Фрукты",
                    "/Resources/fruits.png",
                    new ObservableCollection<Models.Product>{
                        new Models.Product( "Яблоко","Яблоко дружба", 10, "banana"),
                        new Models.Product( "Лимон","Лимон кислый", 20, "Resources\\fruits.png")
                    }
                ),
                new Models.ShopSection(
                    "Овощи",
                    "/Resources/vegetables.png",
                    new ObservableCollection<Models.Product>{
                    new Models.Product( "Огурец","Огурец столичный", 10, "banana"),
                    new Models.Product( "Тыква","Тыква из хэллоуина", 20, "Resources\\fruits.png")
                    }
                )
            };
        }
    }
}
