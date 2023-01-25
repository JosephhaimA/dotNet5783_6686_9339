using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// 


    public partial class ProductWindow : Window
    {
        private Action<int> Action;

        /// <summary>
        /// entering the product update window
        /// </summary>
        public BO.Product? product
        {
            get { return (BO.Product)GetValue(productProperty); }
            set { SetValue(productProperty, value); }
        }
        public static readonly DependencyProperty productProperty = DependencyProperty.Register(
        "product", typeof(BO.Product), typeof(ProductWindow), new PropertyMetadata(default(BO.Product)));
        /// <summary>
        /// initialize the update product window
        /// </summary>
        public ProductWindow(int productID , bool? check = null, Action<int> action = null!)
        {
            product = new();
            InitializeComponent();
            this.Action = action;         
             BlApi.IBl? bl = BlApi.Factory.Get();
            
            if (productID != 0)
            {
                product = bl?.Product.GetProductAdmin(productID);
            }
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(DO.Enums.ProductCategory));

            if (productID != 0 && check == false)
            {
                BackButton.Visibility = Visibility.Hidden;
                Confirm.Visibility = Visibility.Hidden;
            }
            if (productID == 0 && check == false)
            {
                ConfirmUpdate.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Hidden;
            }
            if (check == true)
            {
                Confirm.Visibility = Visibility.Hidden;
                ConfirmUpdate.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Hidden;
                InsertId.IsReadOnly = true;
                InsertName.IsReadOnly = true;
                InsertPrice.IsReadOnly = true;
                InsertCategory.IsReadOnly = true;
                CategorySelct.Visibility = Visibility.Hidden;
                InsertInStock.IsReadOnly = true;
            }
        }

       
        private void ConfirmAdd_Click(object sender, RoutedEventArgs e)
        {
            BlApi.IBl? bl = BlApi.Factory.Get();

            bool check = false;
            try
            {
                Random random = new Random();
                product!.Id = random.Next(100000, 999999);
                bl?.Product.ProductAdd(product);
                check = true;
            }
            catch (BlDoesNotExistException ex)
            {
                MessageBox.Show("❌  " + ex.Message);
            }
            catch (BlAlreadyExistException ex)
            {
                MessageBox.Show("❌  " + ex.Message);
            }
            catch (DO.DalDoesNotExistException ex)
            {
                MessageBox.Show("❌  " + ex.Message);
            }
            if (check == true)
            {
                Confirm.Visibility = Visibility.Hidden;
                Close();
            }
            Action?.Invoke(product!.Id);
            
        }

        private void ConfirmUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;

            BlApi.IBl? bl = BlApi.Factory.Get();

            try
            {
                bl?.Product.ProductUpdate(product);
                check = true;
            }
            catch (Exception)
            {
                MessageBox.Show("the data was rong");
            }
            if(check == true)
            {
                ConfirmUpdate.Visibility = Visibility.Hidden;
                Close();
            }
            Action?.Invoke(product!.Id);
            
        }

        private void CategorySelct_SelectionChanged(object sender, SelectionChangedEventArgs e){}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void InsertCategory_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
