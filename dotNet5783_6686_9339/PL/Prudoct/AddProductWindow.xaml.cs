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
            //InsertCategory.ItemsSource = bl.Product.ListProduct();
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(BO.Enum.ProductCategory));
        }

       
        private void ItemAdd_Click(object sender, RoutedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            BO.Product product= new BO.Product();
            product.Id = int.Parse(InsertId.Text);
            product.Name = InsertName.Text;
            product.Price = int.Parse(InsertPrice.Text);
            product.InStock = int.Parse(InsertInStock.Text);
            //int a = int.Parse(CategorySelector.Items);
            product.Category = (BO.Enum.ProductCategory?)CategorySelct.SelectedItem;
           // product.Category = (BO.Enum.ProductCategory)a;
            bl.Product.ProductAdd(product);
        }

        private void CategorySelct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            InsertCategory.ItemsSource = bl.Product.ListProduct(a => a?.Category.ToString() == CategorySelct.SelectedItem.ToString());
        }
    }
}
