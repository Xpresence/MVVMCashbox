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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace MVVMCashbox
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        UserViewModel model;
        readonly IJsonFileInterface<Product> jsonData = new JsonFileService<Product>();

        public UserWindow()
        {
            InitializeComponent();

            this.Loaded += Window_Loaded;
            this.Closing += Window_Closing;

            model = new UserViewModel();
        }

        // Загрузка данных по событию загруженного окна
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            model.Products = jsonData.Load(@"..\..\data/data.json");
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

    }
}
