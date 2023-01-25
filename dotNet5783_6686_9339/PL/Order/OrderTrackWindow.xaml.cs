using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for OrderTracking.xaml
    /// </summary>
    public partial class OrderTrackWindow : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        int? ID;
        BO.OrderForList? order110 = new BO.OrderForList();

        /// <summary>
        /// prints the order (finds her by id)
        /// </summary>
        public OrderTrackWindow(int? id)
        {
            InitializeComponent();
            IEnumerable<BO.OrderForList?> order10 = new List<BO.OrderForList?>();
            order10 = bl?.Order.OrderList()!;
            order110 = order10.FirstOrDefault(item => id == item!.OrderId);
            BO.OrderTracking? orderTracking = bl?.Order.orderTracking((int)id!)!;
            //OrderTackingText.Text = (bl?.Order.orderTracking((int)id!))?.ToString();
            OrderTackingText.Text = orderTracking.ToString();
           
            ID = id;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Back to main window
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new PL.MainWindow().Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BO.OrderForList? order = new BO.OrderForList();
            BO.OrderTracking? order1 = new BO.OrderTracking();

            order1 = bl?.Order.orderTracking((int)ID!);
            //Action<int>? action = null;
            if (order != null)
            {
                new Order.OrderUpdateAdmineWindow(order110).Show();
               // new Order.UpdateOrder(order, order).Show();
                Close();
            }
        }

    }
}
