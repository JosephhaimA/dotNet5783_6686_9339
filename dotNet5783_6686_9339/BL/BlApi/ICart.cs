using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlApi;
public interface ICart
{
    public Cart AddItemToCART(Cart item, int id );
    public Cart UpdateAmountOfProduct(Cart item, int id, int newAmount);
    public void ConfirmationOfOrder(Cart CostumerInfo);

}


