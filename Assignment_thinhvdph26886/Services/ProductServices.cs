using Assignment_thinhvdph26886.IServices;
using Assignment_thinhvdph26886.Models;


namespace Assignment_thinhvdph26886.Services
{
    public class ProductServices : IProductServices
    {
        ShoppingDbContext context;
        public ProductServices()
        {
            context = new ShoppingDbContext();
        }
        public bool CreateProduct(Product p)
        {
            try
            {
                context.Products.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool DeleteProduct(Guid id)
        {
            try
            {
                var product = context.Products.FirstOrDefault(p => p.ID == id);
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            //return context.Products.Find(id);
            return context.Products.FirstOrDefault(c => c.ID == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return context.Products.Where(c => c.Name.Contains(name)).ToList();
        }

        public List<Product> GetProductsLinq()
        {
            return context.Products.Where(p => p.Price*p.AvailableQuantity >= 10000000).ToList();
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var product = context.Products.Find(p.ID);
                product.Name = p.Name;
                product.Description = p.Description;
                product.Price = p.Price;
                product.Supplier = p.Supplier;
                product.AvailableQuantity = p.AvailableQuantity;
                product.Status = p.Status;
                product.Color = p.Color;
                context.Update(product);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
