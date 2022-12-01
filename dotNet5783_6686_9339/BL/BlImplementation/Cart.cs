using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using DalApi;
using Dal;

namespace BlImplementation;
internal class Cart : ICart
{
    private IDal dal = new Dal.DalList();  //DalList();

    public BO.Cart AddItemToCART(BO.Cart item, int id) { return item; }
    public BO.Cart UpdateAmountOfProduct(BO.Cart item, int id, int newAmount) { return item; }
    public void ConfirmationOfOrder(BO.Cart CostumerInfo) { return; }

}

