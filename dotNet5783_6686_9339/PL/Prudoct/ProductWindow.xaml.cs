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


using BO;

namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        public ProductWindow(ProductForList? product = null)
        {
            InitializeComponent();
            if (product != null)
            {
                CategorySelct.ItemsSource = System.Enum.GetValues(typeof(DO.Enums.ProductCategory));
                Confirm.Visibility = Visibility.Collapsed;
                InsertId.Text = product.ProductId.ToString();
                InsertName.Text = product.ProductName;
                InsertPrice.Text = product.ProductPrice.ToString();
                CategorySelct.Text = product.Category.ToString();
                //IBl? bl = new BlImplementation.Bl();
                BlApi.IBl? bl = BlApi.Factory.Get();
                BO.Product? pro = new BO.Product();
                pro = bl.Product.GetProductAdmin(product.ProductId);
                InsertInStock.Text = pro.InStock.ToString();
            }
            else
            {
                CategorySelct.ItemsSource = System.Enum.GetValues(typeof(BO.Enum.ProductCategory));
                ConfirmUpdate.Visibility = Visibility.Collapsed;
            }

        }

       
        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            //IBl bl = new BlImplementation.Bl();
            BlApi.IBl? bl = BlApi.Factory.Get();
            BO.Product product = new BO.Product();
            bool check = true;
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
                MessageBox.Show("the data was not compltly fool");
                check = false;
                new ProductListWindow().Show();
                Close();
            }
            try
            {
                if (check)
                {
                    bl.Product.ProductAdd(product);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("the data was rong");
               check =false;
                new ProductListWindow().Show();
                Close();
            }
            if (check)
            {
                new ProductListWindow().Show();
                Close();
            }
        }

        private void ConfirmUpdate_Click(object sender, RoutedEventArgs e)
        {
            //IBl bl = new BlImplementation.Bl();
            BlApi.IBl? bl = BlApi.Factory.Get();
            DO.Product product = new DO.Product();
            try
            {
                product.ID = int.Parse(InsertId.Text);
                product.Name = InsertName.Text;
                product.Price = int.Parse(InsertPrice.Text);
                product.InStock = int.Parse(InsertInStock.Text);
                product.Category = (DO.Enums.ProductCategory?)CategorySelct.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show("the data was not compltly fool");
                new ProductListWindow().Show();
                Close();
            }
            try
            {
                bl.Product.ProductUpdate(product);
            }
            catch (Exception)
            {
                MessageBox.Show("the data was rong");
            }
            new ProductListWindow().Show();
            Close();
        }

        private void CategorySelct_SelectionChanged(object sender, SelectionChangedEventArgs e){}
    }
}
