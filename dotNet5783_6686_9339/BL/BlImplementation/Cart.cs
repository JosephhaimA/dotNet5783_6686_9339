using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using BlApi;
using BO;
using DalApi;
using static System.Net.Mime.MediaTypeNames;

namespace BlImplementation;
internal class Cart : ICart
{
    //private DalApi.IDal dal = new Dal.DalList(); 
    DalApi.IDal? dal = DalApi.Factory.Get();

    public BO.Cart AddItemToCART(BO.Cart item, int id)
    {
        //DO.Product? product = dal.Product.GetAll().ToList().Find(itemm => (int)itemm?.ID! == id);//מחזיר לי את המוצר אם אותו איי די
        //DO.Product? product = dal.Product.GetObj(id);
        DO.Product product = dal!.Product.GetObj(id);
        if (product.InStock >= 1)
        {
            product.InStock--;
            dal.Product.Update(product);
        }
        else
            throw new BlDoesNotExistException("Out of stock");
        if (item.orderItemsList == null)
        {
            BO.OrderItem orderItem = new BO.OrderItem
            {
                ProductId = id,
                Id = 21,
                ProductPrice = product.Price,
                SumPrice = product.Price,
                InOrder = product.InStock = 1,
                ProductName = product.Name,
            };
            List<BO.OrderItem> boOrderItems = new List<BO.OrderItem>();
            boOrderItems.Add(orderItem);
            item.orderItemsList = boOrderItems!;
            item.TotalPrice += product.Price;
            return item;
        }
    
            int i = item.orderItemsList!.FindIndex(itemm => (int)itemm!.ProductId == id);
        

        bool exists = item.orderItemsList.Exists(itemm => itemm!.ProductId == id);
        if (exists)
        {
            if ((int)product.InStock! != 0)
            {
                item.orderItemsList[i]!.InOrder++;
                item.orderItemsList[i]!.SumPrice += (double)product.Price!;
                item.TotalPrice += (double)product.Price!;
            }
            else
            {
                throw new BO.BlDoesNotExistException("error");
            }
        }
        else
        {
            bool exist = dal.Product.GetAll()!.ToList().Exists(itemm => (int)itemm?.ID! == id);
            if (exist && (int)product.InStock! != 0)
            {
                BO.OrderItem orderItem = new BO.OrderItem()
                {
                    Id = item.orderItemsList[0]!.Id,
                    ProductId = id,
                    ProductName = (string)product.Name!,
                    ProductPrice = (double)product.Price!,
                    InOrder = 1,
                    SumPrice = (double)product.Price!,
                };
                item.orderItemsList.Add(orderItem);
                item.TotalPrice += (double)product.Price!;
            }
            else
            {
                throw new BO.BlDoesNotExistException("error");
            }
        }
        return item;
    }
    public BO.Cart UpdateAmountOfProduct(BO.Cart item, int id, int newAmount) 
    {
        DO.Product? product = dal!.Product.GetAll()!.ToList().Find(itemm => (int)itemm?.ID! == id);//מחזיר לי את המוצר אם אותו איי די
        int index = item.orderItemsList!.FindIndex(itemm => itemm!.ProductId == id);
        if (index == -1) // שאז זה אומר שלא היה מוצר כזה מלכתחילה 
        {
            for (int i = 0; i < newAmount; i++)
            {
                AddItemToCART(item, id);
            }
            return item;
        }

        int diffrence = newAmount - item.orderItemsList[index]!.InOrder;

        if (newAmount == 0)
        {
            item.orderItemsList.RemoveAt(index);
            item.TotalPrice -= (double)product?.Price! * (-1 * diffrence);
            return item;

        }

        if (diffrence < 0)
        {
            item.orderItemsList[index]!.InOrder = newAmount;
            item.orderItemsList[index]!.SumPrice = (double)product?.Price! * newAmount;
            item.TotalPrice -= (double)product?.Price! * (-1*diffrence);
            return item;

        }

        if (diffrence > 0)
        {
            for (int i = 0; i < diffrence; i++)
            {
                AddItemToCART(item, id);
            }
        }

            return item;
    }
    public void ConfirmationOfOrder(BO.Cart CostumerInfo)
    {
        //foreach (OrderItem? orderItemList in CostumerInfo.orderItemsList!)
        //{
        //    int idProduct = orderItemList!.ProductId;
        //    DO.Product? product = dal!.Product.GetAll()!.ToList().Find(itemm => (int)itemm?.ID! == idProduct);
        //    int InOrder = orderItemList!.InOrder;
        //    if (InOrder >= (int)product?.InStock! || InOrder <= 0)
        //    {
        //        throw new BO.BlNotEnoughInStock("error");
        //    }
        //}

        foreach (var _ in from OrderItem? orderItemList in CostumerInfo.orderItemsList!
                let idProduct = orderItemList!.ProductId
                let product = dal!.Product.GetAll()!.ToList().Find(itemm => (int)itemm?.ID! == idProduct)
                let InOrder = orderItemList!.InOrder
                where InOrder >= (int)product?.InStock! || InOrder <= 0
                select new { })
        {
            throw new BO.BlNotEnoughInStock("error");
        }

        if (CostumerInfo.CostumerName == null)  
        {
            throw new BO.BlNameWasNull("error");
        }

        if (CostumerInfo.CostumerAdress == null)
        {
            throw new BO.BlAdressWasNull("error");

        }

        if (CostumerInfo.CostumerEmail != null && !CostumerInfo.CostumerEmail.Contains("@gmail.com"))
        {
            throw new BlRongEmail("ERROR: rong email");
        }

        DO.Order NewOrder = new DO.Order()
        {
            CostumerName = CostumerInfo.CostumerName,
            CostumerEmail = CostumerInfo.CostumerEmail,
            CostumerAdress = CostumerInfo.CostumerAdress,
            OrderDate = DateTime.Now,
        };

        int NumOreder = dal!.Order.Add(NewOrder);

        CostumerInfo.orderItemsList!
          .Where(orderItemList => orderItemList != null)
          .ToList()
          .ForEach(orderItemList =>
          {
              int intProduct = orderItemList!.ProductId;
              DO.Product product = (DO.Product)dal.Product.GetAll()!.FirstOrDefault(itemm => itemm?.ID == intProduct)!;

              DO.OrderItem NewOrderItem = new DO.OrderItem()
              {
                  ProductID = product.ID,
                  OrderID = NumOreder,
                  Price = product.Price,
                  Amount = orderItemList.InOrder,
              };

              dal.OrderItem.Add(NewOrderItem);
          });


        var products = dal.Product.GetAll()!.ToList();

        CostumerInfo.orderItemsList!.Where(orderItemList => orderItemList != null).ToList().ForEach(orderItemList =>
      {
          int intProduct = orderItemList!.ProductId;
          DO.Product product = (DO.Product)products.FirstOrDefault(itemm => itemm?.ID! == intProduct)!;
          product.InStock -= orderItemList.InOrder;
          dal.Product.Update(product);
      });


        return; 
    }

}

