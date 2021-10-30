using AssignmentDotStark.Contracts;
using AssignmentDotStark.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentDotStark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("GetById")]
        [HttpGet]
        public JsonResult Get(string productId)
        {
            try
            {
                return new JsonResult(_productService.GetById(productId));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var products = _productService.GetAll();

                return products?.Count > 0
                    ? new JsonResult(products)
                    : new JsonResult("Product not found!");
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public async Task<string> Post(ProductAddDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                return await _productService.Save(model).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<string> Put(ProductUpdateDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                return await _productService.Update(model).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
