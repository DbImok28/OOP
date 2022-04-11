using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using lab6.Models;
using lab6.Views.Windows;

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
        #region ShopSections
        private ObservableCollection<ShopSection> _ShopSections;
        public ObservableCollection<ShopSection> ShopSections
        {
            get => _ShopSections;
            set => Set(ref _ShopSections, value);
        }
        #endregion
        #region ShopingCart
        private ObservableCollection<Product> _ShopingCart = new ObservableCollection<Product>();
        public ObservableCollection<Product> ShopingCart
        {
            get => _ShopingCart;
            set => Set(ref _ShopingCart, value);
        }
        #endregion
        #region ShopSections
        private ShopSection _SelectedShopSection;
        public ShopSection SelectedShopSection
        {
            get => _SelectedShopSection;
            set => Set(ref _SelectedShopSection, value);
        }
        #endregion
        #region CurrentLanguage
        private string _CurrentLanguage;
        public string CurrentLanguage
        {
            get => _CurrentLanguage;
            set => Set(ref _CurrentLanguage, value);
        }
        #endregion
        #region Commands
        #region AddToShoppingCart
        public ICommand AddToShoppingCart { get; }
        private void OnAddToShoppingCartCommandExecuted(object par)
        {
            ShopingCart.Add(SelectedProduct);
            OnPropertyChanged(nameof(FullPrice));
        }
        private bool CanAddToShoppingCartCommandExecute(object par) => true;
        #endregion
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }
        private void OnCloseApplicationCommandExecuted(object par) => Application.Current.Shutdown();
        private bool CanCloseApplicationCommandExecute(object par) => true;
        #endregion
        #region OpenProductPageCommand
        public ICommand OpenProductPageCommand { get; }
        private void OnOpenProductPageCommandExecuted(object par)
        {
            SelectedProduct = par as Product;
            CurrentPage = productInfoPage;
        }
        private bool CanOpenProductPageCommandExecute(object par) => true;
        #endregion
        #region OpenHomePageCommand
        public ICommand OpenHomePageCommand { get; }
        private void OnOpenHomePageCommandExecuted(object par) => CurrentPage = homePage;
        private bool CanOpenHomePageCommandExecute(object par) => true;
        #endregion
        #region OpenCompliteShoppingPageCommand
        public ICommand OpenCompliteShoppingPageCommand { get; }
        private void OnOpenCompliteShoppingPageCommandExecuted(object par) => CurrentPage = compliteShopingPage;
        private bool CanOpenCompliteShoppingPageCommandExecute(object par) => true;
        #endregion
        #region RemoveProductCommand
        public ICommand RemoveProductFromShoppingCartCommand { get; }
        private void OnRemoveProductFromShoppingCartCommandExecuted(object par)
        {
            ShopingCart.Remove(par as Product);
            OnPropertyChanged(nameof(FullPrice));
        }
        private bool CanRemoveProductFromShoppingCartCommandExecute(object par) => ShopingCart.Count > 0;
        #endregion
        #region ChangeLanguage
        public ICommand ChangeLanguageCommand { get; }
        private void OnChangeLanguageCommandExecuted(object par)
        {
            //App.ChangeLanguage(par as string);
            if(App.CurrentLanguage == "ru")
            {
                App.ChangeLanguage("en");
            }
            else
            {
                App.ChangeLanguage("ru");
            }
        }
        private bool CanChangeLanguageCommandExecute(object par) => true;
        #endregion
        #endregion
        #region FullPrice
        public decimal FullPrice => ShopingCart.Sum(x => x.Price);
        #endregion
        #region Pages
        private HomePage homePage;
        private ProductInfoPage productInfoPage;
        private CompliteShopingPage compliteShopingPage;
        #region CurrentPage
        private Page _CurrentPage;
        public Page CurrentPage
        {
            get => _CurrentPage;
            set => Set(ref _CurrentPage, value);
        }
        #endregion
        #endregion
        #region SelectedProduct
        private Product _SelectedProduct;
        public Product SelectedProduct
        {
            get => _SelectedProduct;
            set => Set(ref _SelectedProduct, value);
        }
        #endregion
        public MainWindowViewModel()
        {
            #region Commands
            AddToShoppingCart = new Infrastructure.Commands.LambdaCommand(OnAddToShoppingCartCommandExecuted, CanAddToShoppingCartCommandExecute);
            OpenProductPageCommand = new Infrastructure.Commands.LambdaCommand(OnOpenProductPageCommandExecuted, CanOpenProductPageCommandExecute);
            OpenHomePageCommand = new Infrastructure.Commands.LambdaCommand(OnOpenHomePageCommandExecuted, CanOpenHomePageCommandExecute);
            CloseApplicationCommand = new Infrastructure.Commands.LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            OpenCompliteShoppingPageCommand = new Infrastructure.Commands.LambdaCommand(OnOpenCompliteShoppingPageCommandExecuted, CanOpenCompliteShoppingPageCommandExecute);
            RemoveProductFromShoppingCartCommand = new Infrastructure.Commands.LambdaCommand(OnRemoveProductFromShoppingCartCommandExecuted, CanRemoveProductFromShoppingCartCommandExecute);
            ChangeLanguageCommand = new Infrastructure.Commands.LambdaCommand(OnChangeLanguageCommandExecuted, CanChangeLanguageCommandExecute);
            #endregion
            App.UpdateLanguage += (o,e)=> ShopSections = FileReader.DeserializeXML<ObservableCollection<ShopSection>>($"Products_{App.CurrentLanguage}.xml");
            ShopSections = FileReader.DeserializeXML<ObservableCollection<ShopSection>>($"Products_{App.CurrentLanguage}.xml");
            SelectedShopSection = ShopSections[0];
            productInfoPage = new ProductInfoPage(this, RemoveProductFromShoppingCartCommand);
            compliteShopingPage = new CompliteShopingPage(this, RemoveProductFromShoppingCartCommand);
            homePage = new HomePage(this, OpenProductPageCommand, RemoveProductFromShoppingCartCommand);
            CurrentPage = homePage;
        }
    }
}
