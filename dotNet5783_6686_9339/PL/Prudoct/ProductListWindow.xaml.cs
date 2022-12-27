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
using PL.Prudoct;

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
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enum.ProductCategory));
          //  CategorySelector.Items.Add($"{BO.Enum.ProductCategory)})
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IBl bl = new BlImplementation.Bl();
            ProductListView.ItemsSource = bl.Product.ListProduct(a => a?.Category.ToString() == CategorySelector.SelectedItem.ToString());
        }
    }
}
