using DE.Db;
using DE.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;
using System.Globalization;
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

namespace DE
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        bool isLogin = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            TradeEntities db = new TradeEntities();

            string login = tbLogin.Text;
            string password = tbPasswoed.Text;

            try {

                User user = db.Users.Where((u) => u.UserLogin == login && u.UserPassword == password).Single();
                if (user.UserRole == 2) {

                    Manager manager = new Manager();
                    manager.Show();
                    Hide();
                }
                else if (user.UserRole == 1) { 
                
                    Admin admin = new Admin(user.UserID);
                    admin.Show();
                    Hide();
                }
                else {

                    Client client = new Client();
                    client.Show();
                    Hide();                  
                }
                isLogin = true;
                Close();

            }
            catch {

                MessageBox.Show("Неверный логин или пароль!,", " Ошибка!");

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Guest guest = new Guest();
            guest.Show();
            Hide();
        }
    }
}
