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
        //BlApi.IBl? bl = BlApi.Factory.Get();

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
        public ProductWindow(bool check, Action<int> action,  int productID)
        {
            product = new();
            InitializeComponent();
            this.Action = action;
            //if (product != null)
            //{
            //    CategorySelct.ItemsSource = System.Enum.GetValues(typeof(DO.Enums.ProductCategory));
            //    Confirm.Visibility = Visibility.Collapsed;
            //    InsertId.Text = product.ProductId.ToString();
            //    InsertName.Text = product.ProductName;
            //    InsertPrice.Text = product.ProductPrice.ToString();
            //    CategorySelct.Text = product.Category.ToString();

            //    //IBl? bl = new BlImplementation.Bl();
               BlApi.IBl? bl = BlApi.Factory.Get();
            //    BO.Product? pro = new BO.Product();
            //    pro = bl.Product.GetProductAdmin(product.ProductId);
            //    InsertInStock.Text = pro.InStock.ToString();
            //}
            //else
            //{
            //    CategorySelct.ItemsSource = System.Enum.GetValues(typeof(BO.Enum.ProductCategory));
            //    ConfirmUpdate.Visibility = Visibility.Collapsed;
            //}
            //CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.ProductCategory));

            if (productID != 0)
            {
                product = bl?.Product.GetProductAdmin(productID);
            }
            CategorySelct.ItemsSource = System.Enum.GetValues(typeof(DO.Enums.ProductCategory));

            if (productID != 0 && check == false)
            {
                BackButton.Visibility = Visibility.Hidden;
                Confirm.Visibility = Visibility.Hidden;
               // GoBackToProductItem.Visibility = Visibility.Hidden;
              //  TextBoxLable.Content = "Update product:";
            }
            if (productID == 0 && check == false)
            {
                //GoBackToProductItem.Visibility = Visibility.Hidden;
                ConfirmUpdate.Visibility = Visibility.Hidden;
                BackButton.Visibility = Visibility.Hidden;
               // TextBoxLable.Content = "Add product:";
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
              //  TextBoxLable.Content = "See product:";
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
            ////IBl bl = new BlImplementation.Bl();
            //BlApi.IBl? bl = BlApi.Factory.Get();
            //BO.Product product = new BO.Product();
            //bool check = true;
            //try
            //{
            //    product.Id = int.Parse(InsertId.Text);
            //    product.Name = InsertName.Text;
            //    product.Price = int.Parse(InsertPrice.Text);
            //    product.InStock = int.Parse(InsertInStock.Text);
            //    product.Category = (BO.Enum.ProductCategory?)CategorySelct.SelectedItem;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the data was not compltly fool");
            //    check = false;
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //try
            //{
            //    if (check)
            //    {
            //        bl.Product.ProductAdd(product);

            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the data was rong");
            //   check =false;
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //if (check)
            //{
            //    new ProductListWindow().Show();
            //    Close();
            //}
        }

        private void ConfirmUpdate_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;

            ////IBl bl = new BlImplementation.Bl();
            BlApi.IBl? bl = BlApi.Factory.Get();
            //try
            //{
            //    product.ID = int.Parse(InsertId.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the id was not fool");
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //try
            //{
            //    product.Name = InsertName.Text;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the name was not fool");
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //try
            //{
            //    product.Price = int.Parse(InsertPrice.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the price was not fool");
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //try
            //{
            //    product.InStock = int.Parse(InsertInStock.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the stock was not fool");
            //    new ProductListWindow().Show();
            //    Close();
            //}
            //try
            //{
            //    product.Category = (DO.Enums.ProductCategory?)CategorySelct.SelectedItem;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the category was not fool");
            //    new ProductListWindow().Show();
            //    Close();
            //}

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
