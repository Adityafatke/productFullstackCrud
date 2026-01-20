using ProductFullstackWebApplication1.Model;

namespace ProductFullstackWebApplication1.Sevices.Definations
{
    public interface IproductService 
    {
        Task<bool> AddProduct(Product ob);
        Task<bool> UpdateProduct(int id, Product ob);
        Task<bool> DeleteProduct(int id);
        Task<List<Product>> GetProductAllProducts();

    }
}
