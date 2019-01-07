using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace MVVMCashbox
{
    /// <summary>
    /// Логика взаимодействия для StartupWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        ObservableCollection<User> Users;
        readonly IJsonFileInterface<User> jsonData = new JsonFileService<User>();

        public StartupWindow()
        {
            InitializeComponent();

            this.Loaded += Window_Loaded;

            Users = new ObservableCollection<User>();

        }

        // Загрузка данных по событию загруженного окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Users = jsonData.Load(@"..\..\data /users.json");
            ButtonGeneration();
        }

        // Добавление кнопок
        private void ButtonGeneration()
        {
            //Width="150" Height="50" Margin="25"

            foreach (var user in Users)
            {
                Button button = new Button();
                button.Margin = new Thickness(15, 25, 15, 25);
                button.Width = 150;
                button.Height = 50;
                button.Content = user.Name;
                button.Click += Button_User;

                stackPanel.Children.Add(button);
            }
        }

        // Событие для сгенерированных кнопок
        private void Button_User(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (button != null)
            {
                PasswordWindow passwordWindow = new PasswordWindow();

                if (passwordWindow.ShowDialog() == true)
                {
                    var findedUser = Users.Where(nameCheck => nameCheck.Name.Contains(button.Content.ToString()));

                    if (!IsNullOrEmpty(findedUser))
                    {
                        foreach (var user in findedUser)
                        {

                            if (user.IsAdmin)
                            {
                                if (passwordWindow.Password == user.Password)
                                {
                                    AdminWindow adminWindow = new AdminWindow();
                                    adminWindow.Title = "Администратор";
                                    adminWindow.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль!");
                                }
                            }
                            else
                            {
                                if (passwordWindow.Password == user.Password)
                                {
                                    UserWindow userWindow = new UserWindow();
                                    userWindow.Title = user.Name;
                                    userWindow.Show();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Неверный пароль!");
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Авторизация не пройдена!");
                }
            }
        }

        private static bool IsNullOrEmpty(IEnumerable<User> items)
        {
            return items == null || !items.Any();
        }
    }
}
