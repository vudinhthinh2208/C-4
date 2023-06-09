using Assignment_thinhvdph26886.Models;

namespace Assignment_thinhvdph26886.IServices
{
    public interface IProductServices
    {
        public bool CreateProduct(Product p);
        public bool UpdateProduct(Product p);
        public bool DeleteProduct(Guid id);
        public Product GetProductById(Guid id);
        public List<Product> GetProductByName(string name);
        public List<Product> GetAllProducts();
        public List<Product> GetProductsLinq();
    }
}
