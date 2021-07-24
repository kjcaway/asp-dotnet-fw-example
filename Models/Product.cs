using DemoWebApi.Dto.Product;

namespace DemoWebApi.Models
{
    public class Product
    {
        public int productId { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public decimal price { get; set; }

        public Product()
        {
        }

        public Product(ProductReq req)
        {
            this.productId = req.productId;
            this.name = req.name;
            this.category = req.category;
            this.price = req.price;
        }
    }
}