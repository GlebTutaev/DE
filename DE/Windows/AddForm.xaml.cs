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
    /// Логика взаимодействия для AddForm.xaml
    /// </summary>
    public partial class AddForm : Window
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TradeEntities db = new TradeEntities();

            var newProduct = new Product
            {
                ProductDescription = Description.Text,
                ProductName = NameProduct.Text,
                ProductArticleNumber = Article.Text,
                //ProductCost = 0,
                //ProductMaxDiscount = 0,




            };
            
            db.Products.Add(newProduct);
            db.SaveChanges();
            Close();

        }
    }
}
