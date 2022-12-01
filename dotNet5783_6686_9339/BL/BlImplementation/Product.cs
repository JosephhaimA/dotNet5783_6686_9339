using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using BlApi;

namespace BlImplementation;
internal class Product : IProduct
{
    private DalApi.IDal Dal = new Dal.DalList();

    public BO.Product GetProductAdmin(int id)
    {
        throw new NotImplementedException();
    }

    public BO.ProductItem GetProductAdminCostumer(int id, BO.Cart cart)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.ProductForList> ListProduct()
    {
        throw new NotImplementedException();
    }

    public void ProductAdd(int id, string name, double price, BO.ProductCategory category, int intStock)
    {
        throw new NotImplementedException();
    }

    public void ProductDelete(int id)
    {
        throw new NotImplementedException();
    }

    public void ProductUpdate(BO.Product product)
    {
        throw new NotImplementedException();
    }

}

