using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;

namespace BlImplementation;
internal class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    public IEnumerable<BO.ProductForList> ListProduct()
    {
        List<DO.Product> L_P = dal.Product.GetAll().ToList();
        List<BO.ProductForList> productForLists = new List<BO.ProductForList>();
        for (int i = 0; i < L_P.Count; i++)
        {
            productForLists[i].ProductId = L_P[i].ID;
            productForLists[i].ProductName = L_P[i].Name;
            productForLists[i].ProductPrice = L_P[i].Price;
            int cat = (int)L_P[i].Category;
            productForLists[i].Category = (BO.ProductCategory)cat;
        }
        return productForLists;
    }

    public BO.Product GetProductAdmin(int id)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category;
            product = dal.Product.GetObj(id);
            BO.Product NewProduct = new BO.Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.ProductCategory)cat,
                InStock = product.InStock,
            };
            return NewProduct;
        }
        else
        {
            throw new Exception("ERROR the id was - ");
        }
    }

    public BO.ProductItem GetProductAdminCostumer(int id, BO.Cart cart)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category;
            product = dal.Product.GetObj(id);
            bool exsixs;
            if (product.InStock != 0)
                exsixs = true;
            else
                exsixs = false;
            BO.ProductItem productItem = new BO.ProductItem()
            {
                ProductId = product.ID,
                ProductName = product.Name,
                ProductPrice = product.Price,
                Category = (BO.ProductCategory)cat,
                InStock = exsixs,
                Amount = product.InStock,
            };
            return productItem;
        }
        else
        {
            throw new Exception("ERROR the id was - ");
        }
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

