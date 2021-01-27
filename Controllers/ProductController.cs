using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testeA.Data;
using testeA.Models;


namespace testeA.Controllers
{
    [ApiController]
    [Route("v1/categories")]

    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]

        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var products = await context.Categories.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("/{id:int}")]

        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]

        public async Task<ActionResult<Product>> GetByCategory([FromServices] DataContext context, int id)
        {
            var product = await context.Products.Include(x => x.Category)
                .where(x => x.CategoryId == id).ToListAsync();
            return product;
        }

        [HttpPost]
        [Route("")]

        public async Task<ActionResult<Product>> Post(
            [FromServices] DataContext context,
            [FromBody]Product model)
            {

            if (ModelState.IsValid)
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return model;
            } else 
            {
                return BadRequest(ModelState);
            }
            }
    }
}