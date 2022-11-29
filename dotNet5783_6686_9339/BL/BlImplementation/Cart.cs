using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;
namespace BlImplementation;
internal class Cart : ICart
{
    public Cart AddItemToCART(Cart item, int id) { return item; }
    public Cart UpdateAmountOfProduct(Cart item, int id, int newAmount) { return item; }
    public void ConfirmationOfOrder(Cart CostumerInfo) { }

}

