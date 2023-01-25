using BlApi;
using BO;
using PL.Order;
using PL.Prudoct;
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

namespace PL.Cart
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        BO.Cart NewCart = new BO.Cart();

        public CartWindow(BO.Cart cart)
        {
            InitializeComponent();
            TotalPayment.Text = cart.TotalPrice.ToString();
            CartOrderIteamListView.ItemsSource = cart.orderItemsList;
            NewCart = cart;
        }
       

        private void ConfirmCart_Click(object sender, RoutedEventArgs e)
        {
            NewCart.CostumerName = insertName.Text;
            NewCart.CostumerAdress = InsertAdress.Text;
            NewCart.CostumerEmail = InsertEmail.Text;
            try
            {
                bl!.Cart.ConfirmationOfOrder(NewCart);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Thank you for buying from us 🥳");
            Close();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderItem? orderItem = new BO.OrderItem();


            orderItem = (sender as Button)?.Tag as BO.OrderItem;
           
            try
            {
                bl!.Cart.UpdateAmountOfProduct(NewCart, orderItem!.ProductId, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Succesfuly delete");
            new CartWindow(NewCart).Show();
            Close();
        }
        private void plusButton_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderItem? orderItem = new BO.OrderItem();
            orderItem = (sender as Button)?.Tag as BO.OrderItem;
            int num = orderItem!.InOrder + 1;
            try
            {
                bl!.Cart.UpdateAmountOfProduct(NewCart, orderItem!.ProductId, num);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Succesfuly + ");
            new CartWindow(NewCart).Show();
            Close();
        }
        private void minusButton_Click(object sender, RoutedEventArgs e)
        {
            BO.OrderItem? orderItem = new BO.OrderItem();
            orderItem = (sender as Button)?.Tag as BO.OrderItem;
            int num = orderItem!.InOrder - 1;

            try
            {
                bl!.Cart.UpdateAmountOfProduct(NewCart, orderItem!.ProductId,num );

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Succesfuly - ");
            new CartWindow(NewCart).Show();
            Close();
        }
    }
}
