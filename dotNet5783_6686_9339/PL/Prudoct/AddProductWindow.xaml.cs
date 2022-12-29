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
using BlImplementation;
using BO;
using BlApi;

namespace PL.Prudoct
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        IBl bl = new BlImplementation.Bl();


        public AddProductWindow()
        {
            InitializeComponent();
        }

       
        private void ItemAdd_Click(object sender, RoutedEventArgs e)
        {
            BO.Product product= new BO.Product();
            //int.TryParse(InsertId.Text, out a);
           // product.Id = InsertId.Text;







            bl.Product.ProductAdd(product);
        }
    }
}
