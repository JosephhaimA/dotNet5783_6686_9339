
using DalApi;
using DO;
using System.ComponentModel.Design;
using System.Xml.Linq;

namespace Dal;

public class DalProduct : IProduct
{
    public int ProductAdd(Product p) // function add a product
    {
        
        int i = DataSource.Config.IndexProduct;
        if (i < 50)
        {
            DataSource.ProductList.Add(p);
            DataSource.Config.IndexProduct++;
            return DataSource.ProductList[i].ID;
        }
        else
            throw new Exception("No such place to add a Product you have to remove one");
    }

    public Product ShowProduct(int id) // function to return one product
    {
        //Console.WriteLine(DataSource.ProductList[id].ID);
        //Console.WriteLine("aaaaaaaaaaaaaaaaa");

        int index = ProductFind(id);
        //Console.WriteLine(index);
        //Console.WriteLine(DataSource.ProductList[index].ID);
        //Console.WriteLine(DataSource.Config.IndexProduct);

        if (index != -999)
            return DataSource.ProductList[index]; // return the product 
        else
            throw new Exception("Product doesn't exist");
        
    }
    public void ShowAllProduct() // print all the products
    {
        foreach (Product element in DataSource.ProductList)
        {
            if (element.ID != 0)
                Console.WriteLine(element);
        }
    }
    public void ProductsUpdate(Product p) // updating the product if exist, the price, the stock of the prudcut,....
    {
        int index = ProductFind(p.ID);
        if (index != -999)
        {
            ProductsDelete(index);
            DataSource.ProductList.Add(p);
        }
        else
            throw new Exception("Product does not exist");
    }

    public void ProductsDelete(int id)
    {
        int index = ProductFind(id);
        if (index != -999) // if the id don't exist we cannot delete any product
        {
            
           // for (int i = index; i < DataSource.ProductList.Count - 1; i++)
            //{
               // Product pro;
                for (int j = 0; j < DataSource.ProductList.Count; j++)
                {
                    if (id == DataSource.ProductList[j].ID)
                    {
                        DataSource.ProductList.Remove(DataSource.ProductList[j]);
                    }
                        //pro = DataSource.ProductList[j];
                }
                //DataSource.ProductList[i] = DataSource.ProductList[1 + i];// jump the product at the arra[index] and copy the rest
              //  DataSource.ProductList.Remove(pro);
                //if (i + 1 == DataSource.ProductList.Count)
                   // break;
           // }
            DataSource.ProductList.SkipLast(1).ToArray();// delete the last product beacause we copied at the last place
        }
        else
            throw new Exception("Product does not exist");
    }

    // find function that help us with the main function like add, delete..... to check the exist
    public int ProductFind(int id)
    {
        for (int i = 0; i < DataSource.ProductList.Count; i++)
        {
            if (id == DataSource.ProductList[i].ID)
                return i;
        }
        return -999;
    }
}