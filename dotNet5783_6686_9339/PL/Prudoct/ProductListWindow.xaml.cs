using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PL.admin_option;

namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ObservableCollection<BO.ProductForList?> products
        {
            get { return (ObservableCollection<BO.ProductForList?>)GetValue(productsProperty); }
            set { SetValue(productsProperty, value); }
        }
        public static readonly DependencyProperty productsProperty = DependencyProperty.Register(
        "products", typeof(ObservableCollection<BO.ProductForList?>), typeof(ProductListWindow), new PropertyMetadata(default(List<BO.ProductForList?>)));

        public ProductListWindow()
        {

            InitializeComponent();

            BlApi.IBl? bl = BlApi.Factory.Get();
            ProductListView.ItemsSource = bl?.Product.ListProduct();
            products = new ObservableCollection<BO.ProductForList?>(bl.Product.ListProduct());

            for (int i = 0; i < 5; i++)
            {
                CategorySelector.Items.Add($"{(BO.Enum.ProductCategory)i}");
            }
            CategorySelector.Items.Add("Show all the categorys");
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BlApi.IBl? bl = BlApi.Factory.Get();
            if (CategorySelector.SelectedItem.ToString() != "Show all the categorys")
                ProductListView.ItemsSource = bl.Product.ListProduct(a => a?.Category.ToString() == CategorySelector.SelectedItem.ToString());
            else
                ProductListView.ItemsSource = bl?.Product.ListProduct();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            BO.ProductForList product = new BO.ProductForList();
            product.ProductId = 0;
            new ProductWindow(product.ProductId,false, ProductADD).Show();
        }

        private void doubleClick(object sender, MouseButtonEventArgs e)
        {
            BO.ProductForList product = new BO.ProductForList();
            product = (BO.ProductForList)ProductListView.SelectedItem;
            if (product != null)
            {
                product = (BO.ProductForList)ProductListView.SelectedItem;
                new ProductWindow(product.ProductId,false, UpdateToProducts).Show();
            }
        }

        private void UpdateToProducts(int productID)
        {
            BlApi.IBl? bl = BlApi.Factory.Get();

            var x = ProductListView.SelectedIndex;
            products[x] = (bl?.Product.ListProduct(a => a?.ID == productID).First());
        }
        private void ProductADD(int productID)
        {
            BlApi.IBl? bl = BlApi.Factory.Get();

            BO.ProductForList? p = (bl?.Product.ListProduct(a => a?.ID == productID)!).First();
            products.Add(p);
        }
        private void ProductListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BackButon_Click(object sender, RoutedEventArgs e)
        {
            new ProductOrOrder_AdminWindow().Show();
            Close();
        }
    }
}
