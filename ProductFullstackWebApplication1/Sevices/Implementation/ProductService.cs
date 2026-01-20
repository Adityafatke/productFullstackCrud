using ProductFullstackWebApplication1.Model;
using ProductFullstackWebApplication1.Repository.Definations;
using ProductFullstackWebApplication1.Sevices.Definations;

namespace ProductFullstackWebApplication1.Sevices.Implementation
{
    public class ProductService : IproductService
    {
      private readonly IproductRepository Repo;

        public ProductService(IproductRepository repo)
        {
            this.Repo = repo;  
        }
        public async Task<bool> AddProduct(Product ob)
        {
           bool resp= await Repo.IsExist(ob.Name, ob.Price);
            if(!resp && ob.Price>0)
            {
               return await Repo.AddProduct(ob);
            }
            return false;

        }

        public async Task<bool> DeleteProduct(int id)
        {
          var data= await Repo.GetProductById(id);
            if(data!=null)
            {
               return await Repo.DeleteProduct(id, data);
            }
            return false;
        }

        public async Task<List<Product>> GetProductAllProducts()
        {
            return await Repo.GetProductAllProducts();

        }

        public async Task<bool> UpdateProduct(int id, Product ob)
        {
           var productdata= await Repo.GetProductById(id);
            if (productdata == null)
            {
                return false;
            }
            else
            {
                return await Repo.UpdateProduct(id, ob);
            }
            
        }
    }

}
