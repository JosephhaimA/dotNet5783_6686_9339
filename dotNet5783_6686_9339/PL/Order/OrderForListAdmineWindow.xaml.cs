using DO;
using PL.admin_option;
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
    /// Interaction logic for OrderForList.xaml
    /// </summary>
    public partial class OrderForListAdmineWindow : Window
    {

        public OrderForListAdmineWindow()
        {
            InitializeComponent();
            BlApi.IBl? bl = BlApi.Factory.Get();
            OrderListView.ItemsSource = bl?.Order.OrderList();
        }

        private void OrderListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void doubleClickForUpdate(object sender, MouseButtonEventArgs e)
        {
            BO.OrderForList Order = new BO.OrderForList();
            Order = (BO.OrderForList)OrderListView.SelectedItem;
            if (Order != null)
            {
                new OrderUpdateAdmineWindow(Order).Show();
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new ProductOrOrder_AdminWindow().Show();
            Close();
        }
    }
}
