using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
using DO;
using static BO.Enum;
using static DO.Enums;
// we implement the functions thay we've created

namespace BlImplementation;
sealed public class Product : IProduct
{
    private DalApi.IDal dal = new Dal.DalList();

    public IEnumerable<BO.ProductForList?> ListProduct(Func<DO.Product?, bool>? func)
    {
        List<DO.Product?> L_P = dal.Product.GetAll().ToList();
        List<BO.ProductForList> productForLists = new List<BO.ProductForList>();
        if (func == null)
        {
            for (int i = 0; i < L_P.Count; i++)
            {
                BO.ProductForList PFR = new BO.ProductForList()
                {
                    ProductId = (int)L_P[i]?.ID!,
                    ProductName = (string)L_P[i]?.Name!,
                    ProductPrice = (double)L_P[i]?.Price!,
                    Category = (BO.Enum.ProductCategory?)L_P[i]?.Category!,
                };
                productForLists.Add(PFR);
            }
      
        }
        else
        {
            for (int i = 0; i < L_P.Count; i++)
            {
                if (func(L_P[i]))
                {
                    BO.ProductForList PFR = new BO.ProductForList()
                    {
                        ProductId = (int)L_P[i]?.ID!,
                        ProductName = (string)L_P[i]?.Name!,
                        ProductPrice = (double)L_P[i]?.Price!,
                        Category = (BO.Enum.ProductCategory?)L_P[i]?.Category!,
                    };
                    productForLists.Add(PFR);
                }
            }

        }
        return productForLists;
    }
    
    // for the admin access
    public BO.Product GetProductAdmin(int id)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category!;
            product = dal.Product.GetObj(id);
            BO.Product NewProduct = new BO.Product()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Category = (BO.Enum.ProductCategory)cat,
                InStock = (int)product.InStock!,
            };
            return NewProduct;
        }
        else
        {
            throw new BO.BlIdNegative("ERROR the id was - ");
        }
    }

    public BO.ProductItem GetProductAdminCostumer(int id, BO.Cart cart)
    {
        if (id > 0)
        {
            DO.Product product = new DO.Product();
            int cat = (int)product.Category!;
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
                Category = (BO.Enum.ProductCategory)cat,
                InStock = exsixs,
                Amount = (int)product.InStock!,
            };
            return productItem;
        }
        else
        {
            throw new BO.BlIdNegative("ERROR the id was - ");
        }
    }

    public void ProductAdd(BO.Product product)
    {
        if (product.Id <= 0)
        {
            throw new BO.BlIdNegative("ERROR: ID WAS -");
        }

        if (product.Name == null)
        {
            throw new BO.BlNameWasNull("Error: the name empty");
        }

        if (product.Price <= 0)
        {
            throw new BO.BlInPriceNegative("ERROR: price WAS -");
        }

        if (product.InStock <= 0)
        {
            throw new BO.BlInStockIsNegative("Error: in stock was negativ");
        }

        DO.Product product1 = new DO.Product()
        {
            ID = product.Id,
            Name = product.Name,    
            Price = product.Price,
            Category = (DO.Enums.ProductCategory)product.Category!,
            InStock = product.InStock
        };
        try
        {
            dal.Product.Add(product1);

        }
        catch (Exception mas)
        {
            throw new BO.BlAlreadyExistException("invalid product operation",mas);
        }
    }

    public void ProductDelete(int id)
    {
        List<DO.OrderItem?> ListItem = new List<DO.OrderItem?>();
        ListItem = dal.OrderItem.GetAll().ToList();
        for (int i = 0; i < ListItem.Count; i++)
        {
            if ((int)ListItem[i]?.ProductID==id)
            {
                throw new BO.BlCantDeleteB_Used("error cant delete because the product is usd ");
            }
        }
        try
        {
            dal.Product.Delete(id);
        }
        catch (Exception masg)
        {

            throw new BO.BlDoesNotExistException("ERROR: not exist " + masg) ;
        }
    }

    public void ProductUpdate(DO.Product product)
    {
        if (product.ID <= 0)
        {
            throw new BO.BlIdNegative("ERROR: ID WAS -");
        }

        if (product.Name == null)
        {
            throw new BO.BlNameWasNull("the name empty");
        }

        if (product.Price <= 0)
        {
            throw new BO.BlInPriceNegative("ERROR: price WAS -");
        }

        if (product.InStock <= 0)
        {
            throw new BO.BlInStockIsNegative("ERROR in stock WAS -");
        }

        try
        {
            dal.Product.Update(product);

        }
        catch (Exception mas)
        {
            throw new BO.BlDoesNotExistException("Error: not exist " + mas);
        }
    }

}

