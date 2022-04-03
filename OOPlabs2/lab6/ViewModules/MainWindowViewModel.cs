using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using lab6.Models;

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
        private ObservableCollection<ShopSection> _ShopSections;
        public ObservableCollection<ShopSection> ShopSections
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

            ShopSections = new ObservableCollection<ShopSection> {
                new ShopSection(
                    "Фрукты",
                    "/Resources/fruits.png",
                    new ObservableCollection<Product>{
                        new Product( "Яблоко","Яблоко дружба", 15, "/Resources/apple.png"),
                        new Product( "Груша","Груша богатырская", 20, "/Resources/pear.png"),
                        new Product( "Персик","Персик заморский", 30, "/Resources/peach.png"),
                        new Product( "Лимон","Лимон кислый", 20, "/Resources/lemon.png"),
                        new Product( "Банан","Банан вкусный", 15, "/Resources/banana.png")
                    }
                ),
                new ShopSection(
                    "Овощи",
                    "/Resources/vegetables.png",
                    new ObservableCollection<Product>{
                    new Product( "Огурец","Огурец столичный", 8, "/Resources/cucumber.png"),
                    new Product( "Морковь","Морква деревенска", 8, "/Resources/carrot.png"),
                    new Product( "Тыква","Тыква из хэллоуина", 45, "/Resources/pumpkins.png"),
                    new Product( "Лук","Лук зеленый", 20, "/Resources/onion.png"),
                    new Product( "Капуста","Капуста земная", 20, "/Resources/cabbage.png")
                    }
                ),new ShopSection(
                    "Ягоды",
                    "/Resources/berries.png",
                    new ObservableCollection<Product>{
                    new Product( "Виноград","Виноград кислый", 10, "/Resources/grapes.png"),
                    new Product( "Черника","Черника ночная", 20, "/Resources/blueberry.png"),
                    new Product( "Вишня","Вишня синяя", 20, "/Resources/cherry.png")
                    }
                )
            };
        }
    }
}
