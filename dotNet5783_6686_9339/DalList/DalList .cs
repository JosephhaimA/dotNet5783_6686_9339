using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using DalApi;
using DO;
namespace Dal;


sealed public class DalList : IDal
{
    public IOrder Order => new DalOrder();
    public IOrderIteam OrderIteam => new DalOrderItem();
    public IProduct product => new DalProduct();
}