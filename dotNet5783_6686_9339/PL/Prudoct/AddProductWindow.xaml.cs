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

using BlApi;
using BlImplementation;
using BO;

namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            IBl bl = new BlImplementation.Bl();
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(BO.Enum.ProductCategory));
        }

       
        private void ItemAdd_Click(object sender, RoutedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            BO.Product product = new BO.Product();
            try
            {
                product.Id = int.Parse(InsertId.Text);
                product.Name = InsertName.Text;
                product.Price = int.Parse(InsertPrice.Text);
                product.InStock = int.Parse(InsertInStock.Text);
                product.Category = (BO.Enum.ProductCategory?)CategorySelct.SelectedItem;
            }
            catch (Exception)
            {

                throw;//////////////גם פה אותו דבר רק לשגיאה של היא הכנסת ערכים לכל השדות
            }
            try
            {
                bl.Product.ProductAdd(product);
            }
            catch (Exception)
            {

                throw; ////////////פה לעשות שיקפוץ חלון שכתוב בו את השגיאה
            }
            new ProductListWindow().Show();
            Close();
        }

        private void CategorySelct_SelectionChanged(object sender, SelectionChangedEventArgs e){}
    }
}
