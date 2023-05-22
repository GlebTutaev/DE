using DE.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для EditForm.xaml
    /// </summary>
    public partial class EditForm : Window
    {
        
        public EditForm( string i)
        {
            InitializeComponent();

            TradeEntities db = new TradeEntities();
            Product product = db.Products.Where((u) => u.ProductArticleNumber == i).Single();
            Article.Content = product.ProductArticleNumber;
            NameProduct.Text = product.ProductName;
            Description.Text = product.ProductDescription;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TradeEntities db = new TradeEntities();

            var product = db.Products.Where(x => x.ProductArticleNumber == Article.Content).FirstOrDefault();

            product.ProductName = NameProduct.Text;
            product.ProductDescription = Description.Text;

            db.SaveChanges();
            Close();

        }
    }
}
