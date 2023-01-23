﻿using System;
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
            //BlApi.IBl? bl = BlApi.Factory.Get();
            //BO.Order order = new BO.Order();
            //bool check = true;
            //try
            //{
            //    order.Id = int.Parse(ID.Text);
            //    order.CostumerName = NameUpdate.Text;
            //    order.CostumerEmail = EmailUpdate.Text;
            //    order.CostumerAdress = AdressUpdate.Text;
            //    //order.Status = (BO.Enum.OrderStatus)StatusUpdate.Text.ToString();
            //    order.OrderDate = StatusUpdate.Text;
            //    order.ShipDate
            //    order.DeliveryDate
            //    order.TotalPrice = int.Parse(TotalPriceUpdate.Text);
            //    //(BO.Enum.ProductCategory?)CategorySelct.SelectedItem;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("the data was not compltly fool");
            //    check = false;
            //    new ProductListWindow().Show();
            //    Close();
            //}
            try
            {
                if (check)
                {
                    bl.Order.ShipOrderUpate(order);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("the data was rong");
                check = false;
                new ProductListWindow().Show();
                Close();
            }
            if (check)
            {
                new ProductListWindow().Show();
                Close();
            }
            bl.Order.ShipOrderUpate(order1)

            new OrderForListAdmineWindow().Show();
            Close();
        }
    }
}
