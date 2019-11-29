using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Products prds;

        public ProductController()
        {
            prds = new Products();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(prds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }
    }
}