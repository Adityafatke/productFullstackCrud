using Microsoft.EntityFrameworkCore;
using ProductFullstackWebApplication1.Data;
using ProductFullstackWebApplication1.Model;
using ProductFullstackWebApplication1.Repository.Definations;

namespace ProductFullstackWebApplication1.Repository.Implementation
{
    public class ProductRepository : IproductRepository
    {
       private readonly ProductDbContext DbConn;
        public ProductRepository(ProductDbContext Connection)
        {
            this.DbConn = Connection;
        }
        public async Task<bool> AddProduct(Product ob)
        {
           await  DbConn.ProductTBL.AddAsync(ob);
           return await DbConn.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteProduct(int id,Product ob)
        {

             DbConn.ProductTBL.Remove(ob);
             return await DbConn.SaveChangesAsync()>0;
            

        }

        public async Task<List<Product>> GetProductAllProducts()
        {
            var list = DbConn.ProductTBL.ToList();
            return list;
        }

        public async Task<bool> IsExist(string name, decimal price)
        {
           return await DbConn.ProductTBL.AnyAsync(ob => ob.Name == name && ob.Price == price);
        }

        public async Task<bool> UpdateProduct(int id, Product ob)
        {
           var data= await DbConn.ProductTBL.FirstOrDefaultAsync(ob=>ob.Id==id);
            data.Name = ob.Name;
            data.Price = ob.Price;
            data.ImgUrl = ob.ImgUrl;
            data.Category = ob.Category;
            return await DbConn.SaveChangesAsync()>0;
            
                

        }
       public async Task<Product> GetProductById(int id)
        {
          return  await DbConn.ProductTBL.FirstOrDefaultAsync(ob => ob.Id == id);
        }

         async Task<Product> IproductRepository.GetProductById(int id)
        {
            return await GetProductById(id);
        }
    }
}
