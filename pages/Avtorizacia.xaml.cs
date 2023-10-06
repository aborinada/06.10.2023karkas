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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourAgentstvo.classes;

namespace TourAgentstvo.pages
{
    /// <summary>
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Avtorizacia()
        {
            InitializeComponent();

            connect.modelbd = new model.karkasEntities();
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Registr());
        }

       

        private void Vxod(object sender, RoutedEventArgs e)
        {

            var userObj = connect.modelbd.Data.FirstOrDefault(
                x => x.login == login.Text && passwordBox.Password == x.password);

            if (userObj == null)
            {
                MessageBox.Show("Пользователя с такими данными не существует!", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (userObj.type == 1)
                {
                    Manager.MainFrame.Navigate(new User());
                }
                else if (userObj.type == 2)
                {
                    Manager.MainFrame.Navigate(new Manager());
                }
                else if (userObj.type == 3)
                {
                    Manager.MainFrame.Navigate(new Admin());
                }

            }
        }

      
    }
}