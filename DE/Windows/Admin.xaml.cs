using DE.Db;
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

namespace DE.Windows
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin(int userID)
        {
            InitializeComponent();
            TradeEntities db = new TradeEntities();
            User user = db.Users.Where((u) => u.UserID == userID).Single();
            UserName.Content = user.UserName;
            UserSurname.Content = user.UserSurname;

        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TradeEntities db = new TradeEntities();
            List<Product> product = db.Products.ToList();
            product.ForEach(x =>
            {
                x.ProductStatus = x.ProductQuantityInStock > 0 ? "В наличии" : "Отсутствует";
            });
            ListProduct.ItemsSource = product;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TradeEntities db = new TradeEntities();
            var i = (sender as Button).DataContext as Product;
            try {
                var z = db.OrderProducts.Where(x => x.ProductArticleNumber == i.ProductArticleNumber).Single();
                db.OrderProducts.Remove(z);
                var p = db.Products.Where(x => x.ProductArticleNumber == i.ProductArticleNumber).Single();
                db.Products.Remove(p);
                db.SaveChanges();
                Window_Loaded(sender, e);

            }             
            catch {
                var p = db.Products.Where(x => x.ProductArticleNumber == i.ProductArticleNumber).Single();
                db.Products.Remove(p);
                db.SaveChanges();
                Window_Loaded(sender, e);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Window_Loaded(sender, e);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TradeEntities db = new TradeEntities();
           var i = (sender as Button).DataContext as Product;

            EditForm editForm = new EditForm(i.ProductArticleNumber.ToString());
            editForm.Show();
            
        }
    }
}
