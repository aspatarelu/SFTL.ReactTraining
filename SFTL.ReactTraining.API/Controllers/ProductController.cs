using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SFTL.ReactTraining.API.Models;
using SFTL.ReactTraining.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SFTL.ReactTraining.API.Controllers
{
    [Route("[controller]")]

    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductRepo _productsRepo;

        public ProductController(IProductRepo productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [Route("test2")]
        public ObjectResult Get2()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToArray();
            var response = new { message = "Hello API", claims };
            return new ObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> Get()
        {
            return Ok(await _productsRepo
                .GetProducts()   
                .Include(x=> x.Category)
                .Select(t=> new ProductVM(t))
                .ToListAsync()
                );
        }

        //[HttpPost("add")]
        //[Authorize(Policy = "AdminOnly")]
        //public  Task<ActionResult> AddProduct(ProductVM product)
        //{
        //    return new ObjectResult("")
        //    {
        //        StatusCode = (int)HttpStatusCode.Created
        //    };
        //    //return new ObjectResult(await _productsRepo.AddRestaurantReview(restaurantReviewObj, _userContext.UserId, _userContext.UserRole))
        //    //{
        //    //    StatusCode = (int)HttpStatusCode.Created
        //    //};
        //}
    }
}
