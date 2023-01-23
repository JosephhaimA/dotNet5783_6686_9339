﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PL.Order
{

    /// <summary>
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        BO.Cart cart = new BO.Cart();


        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        //public event PropertyChangedEventHandler PropertyChanged;


        //private ObservableCollection<BO.ProductItem?> _productItem;
        //public ObservableCollection<BO.ProductItem?> productItem
        //{
        //    get { return _productItem; }
        //    set
        //    {
        //        _productItem = value;
        //        OnPropertyChanged(nameof(productItem));
        //    }
        //}

        public NewOrderWindow()
        {
            InitializeComponent();

            BlApi.IBl? bl = BlApi.Factory.Get();
           // productItem = new ObservableCollection<BO.ProductItem>(bl?.Product.GetProductItem()!)!;

            //ProductIteamListView.ItemsSource = bl?.Product.GetProductItem(a => a?.Category.ToString() == CategorySelct.SelectedItem.ToString());
            //ProductIteamListView.ItemsSource = bl?.Product.GetProductItem();
            //ProductIteamListView.
            ProductIteamListView.ItemsSource = bl?.Product.GetProductItem();
            DataContext = bl?.Product.GetProductItem();
            for (int i = 0; i < 5; i++)
            {
                CategorySelct.Items.Add($"{(BO.Enum.ProductCategory)i}");
            }
            CategorySelct.Items.Add("All");
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LastNameCM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CategorySelct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BlApi.IBl? bl = BlApi.Factory.Get();

            if (CategorySelct.SelectedItem.ToString() != "All")
            {
                ProductIteamListView.ItemsSource = bl?.Product.GetProductItem(a => a?.Category.ToString() == CategorySelct.SelectedItem.ToString());
            }
            else
            {
                ProductIteamListView.ItemsSource = bl?.Product.GetProductItem();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BO.ProductItem? product = new BO.ProductItem();
            BlApi.IBl? bl = BlApi.Factory.Get();

            product = (sender as Button)?.DataContext as BO.ProductItem;
            try
            {
                cart = bl?.Cart.AddItemToCART(cart, (int)product?.ProductId!)!;
                MessageBox.Show("Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
