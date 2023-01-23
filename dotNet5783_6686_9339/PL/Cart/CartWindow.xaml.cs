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

        public CartWindow(BO.Cart cart)
        {
            InitializeComponent();
            cart.CostumerName = insertName.Text;
            cart.CostumerAdress = InsertAdress.Text;
            cart.CostumerEmail = InsertEmail.Text;
            TotalPayment.Text = cart.TotalPrice.ToString();
            CartOrderIteamListView.ItemsSource = cart.orderItemsList;

        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
