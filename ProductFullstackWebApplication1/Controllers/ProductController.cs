using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductFullstackWebApplication1.DTO;
using ProductFullstackWebApplication1.Helpers;
using ProductFullstackWebApplication1.Model;
using ProductFullstackWebApplication1.Helpers;
using ProductFullstackWebApplication1.Sevices.Definations;

namespace ProductFullstackWebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
       private readonly IproductService ServiceOb;
        public ProductController(IproductService Ob)
        {
           this.ServiceOb = Ob;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddProduct([FromBody] Product Ob)
        {
           
           bool resp= await ServiceOb.AddProduct(Ob);
           return resp? Ok(ApiResponse<Product>.SuccessResponse(Ob, "Data Sucessfully Add")) :
           BadRequest( ApiResponse<string>.FailResponse("Product Already Exist..!!"));
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var productList = await ServiceOb.GetProductAllProducts();

            if (productList == null || !productList.Any())
            {
                return BadRequest(ApiResponse<string>.FailResponse("No Records Found"));
            }

            return Ok(ApiResponse<IList<Product>>.SuccessResponse(productList, "Data Fetched Successfully"));
        }

        [HttpDelete("DeleteProduct{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool resp = await ServiceOb.DeleteProduct(id);

            if (!resp)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Product Does Not Exist For Deletion"));
            }

            return Ok(ApiResponse<int>.SuccessResponse(id, "Product Deleted Successfully"));
        }

        [HttpPut("Update{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDTO ob)
        {
            var obj = new Product
            {
                Name = ob.Name,
                ImgUrl = ob.ImgUrl,
                Price = ob.Price,
                Category = ob.Category
            };

            bool resp = await ServiceOb.UpdateProduct(id, obj);

            if (!resp)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Product Not Found or Invalid ID"));
            }

            return Ok(ApiResponse<string>.SuccessResponse("Product Updated Successfully"));
        }




    }
}
