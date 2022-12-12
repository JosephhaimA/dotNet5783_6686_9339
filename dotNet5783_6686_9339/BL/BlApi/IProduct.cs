using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
namespace BlApi;
public interface IProduct
{
    public IEnumerable<ProductForList?> ListProduct();
    public Product GetProductAdmin (int id);
    public ProductItem GetProductAdminCostumer(int id, Cart cart);
    public void ProductAdd(BO.Product product);
    public void ProductDelete (int id);
    public void ProductUpdate (DO.Product product);

}

