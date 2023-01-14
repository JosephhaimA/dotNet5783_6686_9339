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

namespace PL.admin_option
{
    /// <summary>
    /// Interaction logic for ProductOrOrder_Admin.xaml
    /// </summary>
    public partial class ProductOrOrder_AdminWindow : Window
    {
        public ProductOrOrder_AdminWindow()
        {
            InitializeComponent();
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            new ProductListWindow().Show();
            Close();
        }

        private void OrderButton_Click(object sender, RoutedEventArgs e)
        {
            new OrderForListAdmineWindow().Show();
            Close();
            
        }

        private void BackToMenu_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
