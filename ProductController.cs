using Lpg_Backend.Model;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.EF_Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lpg_Backend.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly DbHelpher _db;
        public ProductController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelpher(eF_DataContext);
        }
        // GET: api/<ValuesController>
        [HttpGet("GetProducts")]
       /* [Route("api/[controller]/GetProducts")]*/
        public IEnumerable<ProductModel> GetProducts()
        {
            /* ResponseType type = ResponseType.Success;*/
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();

                if (!data.Any())
                {
                    /*type = ResponseType.NotFound;*/
                    return null;

                }
                return data;

            }
            catch (Exception ex)
            {
                /* type = ResponseType.Failure;*/
                return null;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ProductModel Get(int id)
        {
            return _db.GetProduct(id);
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

