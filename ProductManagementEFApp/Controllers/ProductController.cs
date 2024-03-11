using AutoMapper;
using PM_BLL;
using PM_DAL;
using ProductManagementEFApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementEFApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This method gets a list of products from the Database. It maps the products list with the products list from View
        /// Model and returns the productVMs list.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public JsonResult GetProducts()
        {
            ProductService ps = new ProductService();
            var products = ps.GetProducts();

            List<ProductVM> productVMs = new List<ProductVM>();
            productVMs = Mapper.Map<List<Product>, List<ProductVM>>(products);

            return Json(productVMs, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method addds a product to the Database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            ProductService ps = new ProductService();
            var productAdded = ps.AddProduct(product);
            return Json(productAdded, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method updates a product in the Database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateProduct(Product product)
        {
            ProductService ps = new ProductService();
            var productUpdated = ps.UpdateProduct(product);
            return Json(productUpdated, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method returns a product based on product ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult GetProductById(int id)
        {
            ProductService ps = new ProductService();
            var product = ps.GetProductById(id);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// This method deletes a product from the Database based on the product ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>

        [HttpPost]
        public JsonResult DeleteProduct(int productID)
        {
            ProductService ps = new ProductService();
            if(ps.DeleteProduct(productID))
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            return null;
        }
    }
}