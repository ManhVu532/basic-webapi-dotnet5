using basic_webapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace basic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Create(ProductRequest request)
        {
            var product = new Product
            {
                Name = request.Name,
                UnitPrice = request.UnitPrice,
                Id = Guid.NewGuid()
            };
            products.Add(product);
            return Ok(
                new {
                    Success = true, Data = product
                }
                );
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetById([FromRoute] string Id)
        {
            try
            {
                var product = products.SingleOrDefault(product => product.Id == Guid.Parse(Id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }catch (Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpPut]
        [Route("{Id}")]
        public IActionResult Update([FromRoute] string Id, [FromBody] ProductRequest request)
        {
            try
            {
                var product = products.SingleOrDefault(product => product.Id == Guid.Parse(Id));
                if (product == null)
                {
                    return NotFound();
                }

                product.UnitPrice = request.UnitPrice;
                product.Name = request.Name;

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("{Id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            try
            {
                var product = products.SingleOrDefault(product => product.Id == Guid.Parse(Id));
                if (product == null)
                {
                    return NotFound();
                }
                products.Remove(product);
                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
