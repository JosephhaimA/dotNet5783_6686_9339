
using DalApi;
using DO;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace Dal;

public class DalProduct : IProduct
{
    DataSource ds = DataSource.Instance;
    public int Add(Product p) // function add a Product
    {
        
        int i = DataSource.Config.IndexProduct;
        if (i < 50)
        {
            ds.ProductList.Add(p);
            DataSource.Config.IndexProduct++;
            return (int)ds.ProductList[i]?.ID!;
        }
        else
            throw new Exception("No such place to add a Product you have to remove one");
    }

    public Product GetObj(int id) // function to return one Product
    {
        //Console.WriteLine(DataSource.ProductList[id].ID);
        //Console.WriteLine("aaaaaaaaaaaaaaaaa");

        int index = ProductFind(id);
        //Console.WriteLine(index);
        //Console.WriteLine(DataSource.ProductList[index].ID);
        //Console.WriteLine(DataSource.Config.IndexProduct);

        if (index != -999)
            return (Product)ds.ProductList[index]!; // return the Product 
        else
            throw new Exception("Product doesn't exist");
        
    }
    public IEnumerable<Product?> GetAll(Func<Product?, bool>? func) // print all the products
    {
       // List<Product?> list = new List<Product?>();
        if (func != null)
        {
            //foreach (Product? element in ds.ProductList)
            //{
            //    if (func(element))
            //    {
            //        list.Add(element);
            //    }
            //}
            List<Product?> list = (List<Product?>)
                                  (from pro in ds.ProductList
                                  where func(pro)
                                  select pro);
            return list;
        }
        else
        {
            return ds.ProductList;
        }
    }
    public void Update(Product p) // updating the Product if exist, the price, the stock of the prudcut,....
    {
        //int index = ProductFind(p.ID);
        //if (index != -999)
        //{
        //    Delete(p.ID);
        //    ds.ProductList.Insert(p.ID - 1, p);
        //}
        //else
        //    throw new Exception("Product does not exist");

        int count = ds.ProductList.RemoveAll(st => p.ID == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
        ds.ProductList.Insert(p.ID - 1, p);

    }

    public void Delete(int id)
    {
        //int index = ProductFind(id);
        //if (index != -999) // if the id don't exist we cannot delete any Product
        //{

        //   // for (int i = index; i < DataSource.ProductList.Count - 1; i++)
        //    //{
        //       // Product pro;
        //        for (int j = 0; j < ds.ProductList.Count; j++)
        //        {
        //            if (id == (int)ds.ProductList[j]?.ID!)
        //            {
        //                ds.ProductList.Remove(ds.ProductList[j]);
        //            }
        //                //pro = DataSource.ProductList[j];
        //        }
        //        //DataSource.ProductList[i] = DataSource.ProductList[1 + i];// jump the Product at the arra[index] and copy the rest
        //      //  DataSource.ProductList.Remove(pro);
        //        //if (i + 1 == DataSource.ProductList.Count)
        //           // break;
        //   // }
        //    ds.ProductList.SkipLast(1).ToArray();// delete the last Product beacause we copied at the last place
        //}
        //else
        //    throw new Exception("Product does not exist");
        int count = ds.ProductList.RemoveAll(st => id == st?.ID);
        if (count == 0)
            throw new DO.DalDoesNotExistException("Student");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int ProductFind(int id)
    {
        for (int i = 0; i < ds.ProductList.Count; i++)
        {
            if (id == (int)ds.ProductList[i]?.ID!)
                return i;
        }
        return -999;
    }

    public Product GetSingle(Func<Product?, bool>? func)
    {
        Product product = new Product();
        if (func != null)
        {
            product = (Product)ds.ProductList?.FirstOrDefault(element => func(element))!;
        }
        return product;
    }
}