using lab11.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private ObservableCollection<Users> _UserCol = new ObservableCollection<Users>();
        public ObservableCollection<Users> UserCol
        {
            get => _UserCol;
            set => Set(ref _UserCol, value);
        }
        private ObservableCollection<ChatMessages> _MessagesCol = new ObservableCollection<ChatMessages>();
        public ObservableCollection<ChatMessages> MessagesCol
        {
            get => _MessagesCol;
            set => Set(ref _MessagesCol, value);
        }
        public ICommand AddCommand { get; }
        private void OnAddCommandExecuted(object par)
        {
            var value = par as string;
            using (var context = new DashCodeBDContext())
            {
                var user = new Users()
                {
                    Name = value,
                    Login = $"{value}@mail",
                    PasswordHash = value.GetHashCode().ToString()
                };
                context.Users.Add(user);
                context.SaveChanges();
                UpdateTables();
            }
        }
        private bool CanAddCommandExecute(object par) => true;
        public ICommand RemoveCommand { get; }
        private void OnRemoveCommandExecuted(object par)
        {
            var value = par as string;
            using (var context = new DashCodeBDContext())
            {
                var userToDel = context.Users.Where(x => x.Name == value).ToList();
                if(userToDel.Count > 0)
                {
                    context.Users.RemoveRange(userToDel);
                    context.SaveChanges();
                    UpdateTables();
                }
            }
        }
        private bool CanRemoveCommandExecute(object par) => UserCol.Count > 0;
        public ICommand UpdateCommand { get; }
        private void OnUpdateCommandExecuted(object par)
        {
            var values = (object[])par;
            var source = (string)values[0];
            var target = (string)values[1];
            using (var context = new DashCodeBDContext())
            {
                IEnumerable<Users> users = context.Users
                .Where(c => c.Name == source)
                .Select(c => c.UserId)
                .AsEnumerable()
                .Select(id => new Users
                {
                    UserId = id,
                    Name = target,
                    Login = "{target}@mail",
                });

                foreach (var user in users)
                {
                    context.Users.Attach(user);
                    context.Entry(user)
                        .Property(c => c.Name).IsModified = true;
                }

                context.SaveChanges();
                UpdateTables();
            }
        }
        public void UpdateTables()
        {
            UserCol.Clear();
            MessagesCol.Clear();
            using (var context = new DashCodeBDContext())
            {
                foreach (var item in context.Users.ToList())
                {
                    UserCol.Add(item);
                }
                foreach (var item in context.ChatMessages.ToList())
                {
                    MessagesCol.Add(item);
                }
            }
        }
        private bool CanUpdateCommandExecute(object par) => UserCol.Count > 0;
        public MainWindowViewModel()
        {
            AddCommand = new LambdaCommand(OnAddCommandExecuted, CanAddCommandExecute);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecuted, CanRemoveCommandExecute);
            UpdateCommand = new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
            UpdateTables();
        }
    }
}