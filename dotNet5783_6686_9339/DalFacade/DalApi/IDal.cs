using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;
public class IDal
{
    Product Product { get; }
    Order Order { get; }
    OrderItem OrderItem { get; }
}

