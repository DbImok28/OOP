using lab11.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lab11.ViewModules
{
    internal class MainWindowViewModel : BaseViewModel
    {
        #region Title
        private string _Title = "DashCode";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        private DBDashCode DataBase = new DBDashCode();

        #region Users
        private ObservableCollection<Users> _UserCol = new ObservableCollection<Users>();
        public ObservableCollection<Users> UserCol
        {
            get => _UserCol;
            set => Set(ref _UserCol, value);
        }
        public ICommand AddUserCommand { get; }
        private void OnAddUserCommandExecuted(object par)
        {
            var value = par as string;
            var user = new Users()
            {
                Name = value,
                Login = $"{value}@mail",
                PasswordHash = new byte[20]
            };
            DataBase.Add(user);
            DataBase.SaveChanges();
            UpdateTables();
        }
        public ICommand RemoveUserCommand { get; }
        private void OnRemoveUserCommandExecuted(object par)
        {
            var value = par as string;
            if (DataBase.Remove((Users x) => x.Name == value))
            {
                DataBase.SaveChanges();
                UpdateTables();
            }
        }
        private bool CanRemoveUserCommandExecute(object par) => UserCol.Count > 0;
        public ICommand UpdateUserCommand { get; }
        private void OnUpdateUserCommandExecuted(object par)
        {
            var values = (object[])par;
            var source = (string)values[0];
            var target = (string)values[1];

            DataBase.Update(c => c.Name == source, id => new Users
            {
                UserId = id,
                Name = target,
                Login = $"{target}@mail",
                PasswordHash = new byte[20]
            });
            DataBase.SaveChanges();
            UpdateTables();
        }
        private bool CanUpdateUserCommandExecute(object par) => UserCol.Count > 0;
        #endregion
        #region Chats
        private ObservableCollection<Chats> _ChatsCol = new ObservableCollection<Chats>();
        public ObservableCollection<Chats> ChatsCol
        {
            get => _ChatsCol;
            set => Set(ref _ChatsCol, value);
        }
        public ICommand AddChatCommand { get; }
        private void OnAddChatCommandExecuted(object par)
        {
            var value = par as string;
            var chat = new Chats()
            {
                Name = value
            };
            DataBase.Add(chat);
            DataBase.SaveChanges();
            UpdateTables();
        }
        public ICommand RemoveChatCommand { get; }
        private void OnRemoveChatCommandExecuted(object par)
        {
            var value = par as string;
            if (DataBase.Remove((Chats x) => x.Name == value))
            {
                DataBase.SaveChanges();
                UpdateTables();
            }
        }
        private bool CanRemoveChatCommandExecute(object par) => ChatsCol.Count > 0;
        public ICommand UpdateChatCommand { get; }
        private void OnUpdateChatCommandExecuted(object par)
        {
            var values = (object[])par;
            var source = (string)values[0];
            var target = (string)values[1];

            //DataBase.Update(c => c.Name == source, id => new Chats
            //{
            //    ChatId = id,
            //    Name = target
            //});
            DataBase.Update(c => c.Name == source, id => new Chats
            {
                ChatId = id,
                Name = target,
            });
            DataBase.SaveChanges();
            UpdateTables();
        }
        private bool CanUpdateChatCommandExecute(object par) => ChatsCol.Count > 0;
        #endregion
        public void UpdateTables()
        {
            UserCol.Clear();
            ChatsCol.Clear();

            foreach (var item in DataBase.Users.ToList())
            {
                UserCol.Add(item);
            }
            foreach (var item in DataBase.Chats.ToList())
            {
                ChatsCol.Add(item);
            }
        }
        public MainWindowViewModel()
        {
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted);
            RemoveUserCommand = new LambdaCommand(OnRemoveUserCommandExecuted, CanRemoveUserCommandExecute);
            UpdateUserCommand = new LambdaCommand(OnUpdateUserCommandExecuted, CanUpdateUserCommandExecute);

            AddChatCommand = new LambdaCommand(OnAddChatCommandExecuted);
            RemoveChatCommand = new LambdaCommand(OnRemoveChatCommandExecuted, CanRemoveChatCommandExecute);
            UpdateChatCommand = new LambdaCommand(OnUpdateChatCommandExecuted, CanUpdateChatCommandExecute);
            UpdateTables();
        }
    }
}