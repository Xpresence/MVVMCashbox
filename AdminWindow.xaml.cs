using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;




namespace MVVMCashbox
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        AdminViewModel model;
        readonly IJsonFileInterface<Product> jsonData = new JsonFileService<Product>();

        public AdminWindow()
        {
            InitializeComponent();

            this.Loaded += Window_Loaded;
            this.Closing += Window_Closing;

            model = new AdminViewModel();
        }

        // Загрузка данных по событию загруженного окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            model.Products = jsonData.Load(@"..\..\data /data.json");
            DataContext = model;

        }

        // Сохранение данных по событию закрытия окна
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (model != null)
            {
                jsonData.Save(@"..\..\data/data.json", model.Products);
            }
        }


        // Поступление выбранного товара
        private void Button_Update(object sender, RoutedEventArgs e)
        {
            DialogWindow dialogWindow = new DialogWindow();
            dialogWindow.blockDialogBox.Text = "Введите количество добавляемого товара:";

            if (dialogWindow.ShowDialog() == true)
            {
                int data;
                bool isInt = int.TryParse(dialogWindow.Text, out data);

                if (isInt)
                {
                    var product = model.Products.Where(p => p == model.SelectedProduct).FirstOrDefault();

                    if(product != null)
                    {
                        product.Count += data;
                    }
                }
                else
                {
                    MessageBox.Show("Неверное значение!");
                }
            }

        }

        // Событие нажатия на кнопку редактирования пользователей
        private void Button_EditUsers(object sender, RoutedEventArgs e)
        {
            AdminEditUsersWindow adminEditUsersWindow = new AdminEditUsersWindow();
            adminEditUsersWindow.Title = "Редактирование пользователей";
            adminEditUsersWindow.Show();
        }

        private void Button_Graphics(object sender, RoutedEventArgs e)
        {
            GraphicsWindow graphicsWindow = new GraphicsWindow();
            graphicsWindow.Show();
        }
    }
}
