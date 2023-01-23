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

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for OrderUpdateWindow.xaml
    /// </summary>
    public partial class OrderUpdateAdmineWindow : Window
    {
        public OrderUpdateAdmineWindow(BO.OrderForList order)
        {
            InitializeComponent();
            BlApi.IBl? bl = BlApi.Factory.Get();
            BO.Order order1 = new BO.Order();
            order1 = bl.Order.GetOrder(order.OrderId);
            ListViewOfIsCart.ItemsSource = order1.Details;

            ID.Text = order.OrderId.ToString();
            NameUpdate.Text = order1.CostumerName;
            EmailUpdate.Text = order1.CostumerEmail;
            AdressUpdate.Text = order1.CostumerAdress;
            StatusUpdate.Text = order1.Status.ToString();
            DateOrder.Text = order1.OrderDate.ToString();
            DateSipe.Text = order1.ShipDate.ToString();
            DateDelivery.Text = order1.DeliveryDate.ToString();
            TotalPriceUpdate.Text = order1.TotalPrice.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new OrderForListAdmineWindow().Show();
            Close();
        }
    }
}
