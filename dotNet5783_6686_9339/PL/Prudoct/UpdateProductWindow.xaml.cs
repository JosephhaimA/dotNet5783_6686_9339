using BlApi;
using BO;
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
/*
namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        public UpdateProductWindow(ProductForList product)
        {
            InitializeComponent();
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(DO.Enums.ProductCategory));
            IDText.Text = product.ProductId.ToString();
            NameUpdeteText.Text = product.ProductName;
            PriceUpdateText.Text = product.ProductPrice.ToString();
            CategorySelct.Text = product.Category.ToString();
            //InStockUpdateText.Text = product.
        }

        private void UpDateProduct_Click(object sender, RoutedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            DO.Product product = new DO.Product();
            try
            {
                product.ID = int.Parse(IDText.Text);
                product.Name = NameUpdeteText.Text;
                product.Price = int.Parse(PriceUpdateText.Text);
                product.InStock = int.Parse(InStockUpdateText.Text);
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
    }
}
*/