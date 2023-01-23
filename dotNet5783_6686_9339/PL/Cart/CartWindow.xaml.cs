using BlApi;
using BO;
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
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            //BO.OrderItem orderItem = new BO.OrderItem();
            //orderItem = (BO.OrderItem)sender;
            //new ProductWindow(orderItem.ProductId).Show();
            //Close();
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
            MessageBox.Show("Succeded");
            Close();
        }
    }
}
