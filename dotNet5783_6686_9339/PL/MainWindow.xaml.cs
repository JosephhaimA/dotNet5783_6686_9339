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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PL.admin_option;
using PL.Order;
using PL.Prudoct;

namespace PL;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //IBl bl = new BlImplementation.Bl();
    BlApi.IBl? bl = BlApi.Factory.Get();
    public MainWindow()
    {
        InitializeComponent();
    }

    private void adminButton_Click(object sender, RoutedEventArgs e)
    {
        new ProductOrOrder_AdminWindow().Show();
        Close();
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void NewOrder_Click(object sender, RoutedEventArgs e)
    {
        new NewOrderWindow().Show();
        Close();
    }

    //private void Tracking_Click(object sender, RoutedEventArgs e)
    //{
    //    new OrderTrackWindow().Show();
    //    Close();

    //}

    private void Tracing_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            int? id;
            id = int.TryParse(Tracing.Text, out Temp);
            new OrderTrackWindow().Show();
            Close();
        }
    }
}

