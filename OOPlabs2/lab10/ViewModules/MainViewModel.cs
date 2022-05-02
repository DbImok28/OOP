using lab10.Commands;
using Models.lab10;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab10.ViewModules
{
    public class MainViewModel : BaseViewModel
    {
        private SqlConnection BDConnection;
        #region Title
        private string _Title = "ADO.net lab 10";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        #region User
        private ObservableCollection<User> _Users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get => _Users;
            set => Set(ref _Users, value);
        }
        public ICommand AddUserCommand { get; }
        private void OnAddUserCommandExecuted(object par)
        {
            var value = par as string;
            var user = new User()
            {
                Name = value,
                Login = $"{value}@mail"
            };
            string filename = @"image.png";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                var imageData = new byte[fs.Length];
                fs.Read(imageData, 0, imageData.Length);
                user.Photo = imageData;
            }

            try
            {
                BDConnection.Open();

                var command = new SqlCommand("INSERT INTO USERS(NAME, LOGIN, PASSWORD_HASH, PHOTO) VALUES(@user, @login, HASHBYTES('SHA', CAST(@password AS NVARCHAR(32))), @photo)", BDConnection);
                SqlParameter nameParam = new SqlParameter("@user", user.Name);
                SqlParameter loginParam = new SqlParameter("@login", user.Login);
                SqlParameter passwordParam = new SqlParameter("@password", user.Name.Reverse().ToString());
                SqlParameter photoParam = new SqlParameter("@photo", user.Photo);
                command.Parameters.Add(nameParam);
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passwordParam);
                command.Parameters.Add(photoParam);
                if (command.ExecuteNonQuery() > 0)
                    Users.Add(user);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "INSERT error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        public ICommand RemoveUserCommand { get; }
        private void OnRemoveUserCommandExecuted(object par)
        {
            var name = par as string;
            try
            {
                BDConnection.Open();

                var command = new SqlCommand("DELETE FROM USERS WHERE USERS.NAME = @name", BDConnection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);

                if (command.ExecuteNonQuery() > 0)
                    Users.Remove(Users.Where(u=>u.Name == name).First());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DELETE error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        private bool CanRemoveUserCommandExecute(object par) => Users.Count > 0;
        public ICommand UpdateUserCommand { get; }
        private void OnUpdateUserCommandExecuted(object par)
        {
            var values = (object[])par;
            var source = (string)values[0];
            var target = (string)values[1];
            
            try
            {
                BDConnection.Open();

                var command = new SqlCommand("UPDATE USERS SET NAME = @target WHERE USERS.NAME = @source", BDConnection);
                SqlParameter targetParam = new SqlParameter("@target", target);
                SqlParameter sourceParam = new SqlParameter("@source", source);
                command.Parameters.Add(targetParam);
                command.Parameters.Add(sourceParam);

                if (command.ExecuteNonQuery() > 0)
                {
                    foreach (var user in Users)
                        if (user.Name == source)
                            user.Name = target;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "UPDATE error");
            }
            finally
            {
                BDConnection.Close();
            }
        }

        public bool SortTypeAsc = true;
        public ICommand SortUserCommand { get; }
        private void OnSortUserCommandExecuted(object par)
        {
            try
            {
                BDConnection.Open();
                string command = SortTypeAsc ? "SELECT * FROM USERS ORDER BY NAME DESC" : "SELECT * FROM USERS ORDER BY NAME ASC";
                var reader = new SqlCommand(command, BDConnection).ExecuteReader();
                SortTypeAsc = !SortTypeAsc;
                Users.Clear();
                while (reader.Read())
                {
                    var user = new User()
                    {
                        UserId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Login = reader.GetString(2),
                        PasswordHash = reader.GetSqlBytes(3).Value,
                    };
                    Users.Add(user);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "BDConnection error");
            }
            finally
            {
                BDConnection.Close();
            }
        }

        private ObservableCollection<Chat> _Chats = new ObservableCollection<Chat>();
        public ObservableCollection<Chat> Chats
        {
            get => _Chats;
            set => Set(ref _Chats, value);
        }
        #endregion
        #region Chat
        public ICommand AddChatCommand { get; }
        private void OnAddChatCommandExecuted(object par)
        {
            var value = par as string;
            var chat = new Chat()
            {
                Name = value
            };
            try
            {
                BDConnection.Open();
                var command = new SqlCommand("INSERT INTO CHATS(NAME) VALUES(@name)", BDConnection);
                SqlParameter nameParam = new SqlParameter("@name", value);
                command.Parameters.Add(nameParam);
                if (command.ExecuteNonQuery() > 0)
                    Chats.Add(chat);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "INSERT error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        public ICommand RemoveChatCommand { get; }
        private void OnRemoveChatCommandExecuted(object par)
        {
            var name = par as string;
            try
            {
                BDConnection.Open();
                var command = new SqlCommand("DELETE FROM CHATS WHERE CHATS.NAME = @name", BDConnection);
                SqlParameter nameParam = new SqlParameter("@name", name);
                command.Parameters.Add(nameParam);
                if (command.ExecuteNonQuery() > 0)
                    Chats.Remove(Chats.Where(u => u.Name == name).First());
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DELETE error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        private bool CanRemoveChatCommandExecute(object par) => Users.Count > 0;
        public ICommand UpdateChatCommand { get; }
        private void OnUpdateChatCommandExecuted(object par)
        {
            var values = (object[])par;
            var source = (string)values[0];
            var target = (string)values[1];

            try
            {
                BDConnection.Open();
                var command = new SqlCommand("UPDATE CHATS SET NAME = @target WHERE CHATS.NAME = @source", BDConnection);
                SqlParameter targetParam = new SqlParameter("@target", target);
                SqlParameter sourceParam = new SqlParameter("@source", source);
                command.Parameters.Add(targetParam);
                command.Parameters.Add(sourceParam);
                if (command.ExecuteNonQuery() > 0)
                {
                    foreach (var chat in Chats)
                        if (chat.Name == source)
                            chat.Name = target;
                    OnPropertyChanged("Chats");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "UPDATE error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        public bool SortChatTypeAsc = true;
        public ICommand SortChatCommand { get; }
        private void OnSortChatCommandExecuted(object par)
        {
            try
            {
                BDConnection.Open();
                string command = SortTypeAsc ? "SELECT * FROM CHATS ORDER BY NAME DESC" : "SELECT * FROM CHATS ORDER BY NAME ASC";
                var reader = new SqlCommand(command, BDConnection).ExecuteReader();
                SortTypeAsc = !SortTypeAsc;
                Chats.Clear();
                while (reader.Read())
                {
                    var chat = new Chat()
                    {
                        ChatId = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1)),
                    };
                    Chats.Add(chat);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Sort error");
            }
            finally
            {
                BDConnection.Close();
            }
        }
        #endregion
        public ICommand LoginCommand { get; }
        private void OnLoginCommandExecuted(object par)
        {
            var values = (object[])par;
            var login = (string)values[0];
            var password = (string)values[1];

            SqlTransaction transaction = null;

            try
            {
                BDConnection.Open();
                transaction = BDConnection.BeginTransaction();

                var command = new SqlCommand("CHECK_LOGIN_AND_PASSWORD", BDConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                var returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(returnParameter);

                command.Transaction = transaction;
                command.ExecuteNonQuery();

                if ((int)returnParameter.Value == 1)
                {
                    MessageBox.Show("Верно");
                }
                else
                {
                    MessageBox.Show("Неверно");
                }
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Login error");
                if (transaction != null)
                {
                    transaction.Rollback();
                }
            }
            finally
            {
                BDConnection.Close();
            }
        }
        public MainViewModel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
            BDConnection = new SqlConnection(connectionString);
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecuted);
            UpdateUserCommand = new LambdaCommand(OnUpdateUserCommandExecuted);
            RemoveUserCommand = new LambdaCommand(OnRemoveUserCommandExecuted, CanRemoveUserCommandExecute);
            SortUserCommand = new LambdaCommand(OnSortUserCommandExecuted);

            AddChatCommand = new LambdaCommand(OnAddChatCommandExecuted);
            UpdateChatCommand = new LambdaCommand(OnUpdateChatCommandExecuted);
            RemoveChatCommand = new LambdaCommand(OnRemoveChatCommandExecuted, CanRemoveChatCommandExecute);
            SortChatCommand = new LambdaCommand(OnSortChatCommandExecuted);

            LoginCommand = new LambdaCommand(OnLoginCommandExecuted);
            try
            {
                BDConnection.Open();
                var reader = new SqlCommand("SELECT * FROM USERS", BDConnection).ExecuteReader();
                while (reader.Read())
                {
                    var user = new User()
                    {
                        UserId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Login = reader.GetString(2),
                        PasswordHash = reader.GetSqlBytes(3).Value,
                    };
                    Users.Add(user);
                }
                reader.Close();
                reader = new SqlCommand("SELECT * FROM CHATS", BDConnection).ExecuteReader();
                while (reader.Read())
                {
                    var chat = new Chat()
                    {
                        ChatId = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1)),
                    };
                    Chats.Add(chat);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "BDConnection error");
            }
            finally
            {
                BDConnection.Close();
            }

            try
            {
                BDConnection.Open();

                var adapter = new SqlDataAdapter("SELECT * FROM USERS", BDConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                var commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dataSet);
                

                new SqlCommand("CREATE TABLE test(name nvarchar(32), age int)", BDConnection).ExecuteNonQuery();
                new SqlCommand("INSERT INTO test(name, age) VALUES('vasa', 23)", BDConnection).ExecuteNonQuery();
                new SqlCommand("UPDATE test SET age = 25 WHERE name = 'vasa'", BDConnection).ExecuteNonQuery();
                var reader = new SqlCommand("SELECT * FROM test", BDConnection).ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show($"{reader.GetValue(0)} \t{reader.GetValue(1)}", "SELECT * FROM test");
                }
                reader.Close();
                new SqlCommand("DELETE FROM test WHERE name = 'vasa'", BDConnection).ExecuteNonQuery();
                new SqlCommand("DROP TABLE test", BDConnection).ExecuteNonQuery();

                /*
                    ExecuteNonQuery: просто выполняет sql-выражение и возвращает количество измененных записей. Подходит для sql-выражений INSERT, UPDATE, DELETE.
                    ExecuteReader: выполняет sql-выражение и возвращает строки из таблицы. Подходит для sql-выражения SELECT.
                    ExecuteScalar: выполняет sql-выражение и возвращает одно скалярное значение, например, число. Подходит для sql-выражения SELECT в паре с одной из встроенных функций SQL, как например, Min, Max, Sum, Count.
                 */
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "BDConnection error");
            }
            finally
            {
                BDConnection.Close();
            }

        }
    }
}