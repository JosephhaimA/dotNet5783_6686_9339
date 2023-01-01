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
        public AddProductWindow(ProductForList? product = null)
        {
            InitializeComponent();
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(BO.Enum.ProductCategory));

            if (product != null)
            {
                Confirm.Content = "Confirm the update";
                Confirm.Click -= ConfirmUpdate_Click;
                InsertId.Text = product.ProductId.ToString();
                InsertName.Text = product.ProductName;
                InsertPrice.Text = product.ProductPrice.ToString();
                CategorySelct.Text = product.Category.ToString();
            }
        }

       
        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("the data was not compltly fool");
                
            }
            try
            {
                bl.Product.ProductAdd(product);
            }
            catch (Exception)
            {
                MessageBox.Show("the data was rong");
               
            }
            new ProductListWindow().Show();
            Close();
        }

        private void ConfirmUpdate_Click(object sender, RoutedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
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
