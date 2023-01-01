using BlApi;
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
using BlImplementation;

namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            IBl bl = new BlImplementation.Bl();
            ProductListView.ItemsSource = bl?.Product.ListProduct();
            //CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enum.ProductCategory));
            for (int i = 0; i < 5; i++)
            {
                CategorySelector.Items.Add($"{(BO.Enum.ProductCategory)i}");
            }
            CategorySelector.Items.Add("Show all the categorys");
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            if (CategorySelector.SelectedItem.ToString() != "Show all the categorys")
                ProductListView.ItemsSource = bl.Product.ListProduct(a => a?.Category.ToString() == CategorySelector.SelectedItem.ToString());
            else
                ProductListView.ItemsSource = bl?.Product.ListProduct();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new ProductWindow().Show();
            Close();
        }

        private void doubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.ProductForList product = new BO.ProductForList();
            product = (BO.ProductForList)ProductListView.SelectedItem;
            if (product != null)
            {
                new ProductWindow(product).Show();
                //new UpdateProductWindow(product).Show();
                Close();
            }
        }
    }
}
