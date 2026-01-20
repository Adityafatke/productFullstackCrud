using ProductFullstackWebApplication1.Model;

namespace ProductFullstackWebApplication1.Repository.Definations
{
    public interface IproductRepository
    {
        Task<bool> AddProduct(Product ob);
        Task<bool> UpdateProduct(int id, Product ob);
        Task<bool> IsExist(string name,decimal price);
        Task<bool> DeleteProduct(int id, Product ob);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProductAllProducts();
    }
}
