using DemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi.DataAccess
{
    public interface IProductDA
    {
        List<Product> getProductList();
        Product getProduct(int productId);
        void saveProduct(Product product);
        void updateProduct(Product product);
    }
}
