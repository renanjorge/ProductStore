using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Models;
using Store.Application.Models.Product;
using Store.Domain.Entities;
using Store.Domain.Interfaces.Services;
using System.Linq;

namespace Store.Application.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService,
                                 IProductCategoryService productCategoryService) 
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        public ActionResult Index()
        {
            var categories = _productCategoryService.GetAll();

            var model = new RegisterProductViewModel
            {
                ProductsCategoriesSelectList = categories.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString(),
                }).ToList(),
                IsActive = true
            };

            return View(model);
        }

        [HttpPost]
        [Route("products/list")]
        public IActionResult PagedList(int start, int length)
        {
            var pagedList = _productService.GetPagedList(start, length);

            var productsViewModel = pagedList.products.Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Active = c.IsActive ? "Ativo" : "Inativo",
                Perishable = c.IsPerishable ? "Sim" : "Não",
                CategoryProductName = c.ProductCategory.Name
            });

            var response = new PagedListViewModel<ProductViewModel>
            {
                Data = productsViewModel,
                RecordsTotal = pagedList.total,
                RecordsFiltered = pagedList.total,
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("products")]
        public IActionResult CreateOrUpdate([FromBody] RegisterProductViewModel productRegister)
        {
            try
            {
                var productCategory = _productCategoryService.GetById(productRegister.CategoryProductId);

                var product = new Product
                {
                    Id = productRegister.Id,
                    Name = productRegister.Name,
                    Description = productRegister.Description,
                    ProductCategory = productCategory,
                    IsActive = true,
                    IsPerishable = productRegister.IsPerishable
                };

                if (productRegister.Id > 0)
                {
                    _productService.Update(product);
                } else
                {
                    _productService.Add(product);
                }

                return Ok(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("products/{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                var product = _productService.GetById(id);

                var registerViewModel = new RegisterProductViewModel 
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    IsActive = product.IsActive,
                    IsPerishable = product.IsPerishable,
                    CategoryProductId = product.ProductCategory.Id
                };

                return Ok(registerViewModel);
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }     
        }

        [HttpPut]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpDelete]
        [Route("products/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productService.Delete(id);

                return Ok();
            } catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
