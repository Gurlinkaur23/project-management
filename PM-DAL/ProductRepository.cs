using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_DAL
{
    public class ProductRepository
    {
        /// <summary>
        /// This method returns the list of products from the Database.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProductsRepo()
        {
            EFProductManagementEntities pme = new EFProductManagementEntities();
            return pme.Products.ToList();
        }

        /// <summary>
        /// This methods adds a product to the Database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool AddProductRepo(Product product)
        {
            EFProductManagementEntities pme = new EFProductManagementEntities();
            if(product != null)
            {
                pme.Products.Add(product);
                pme.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method updates the product details in the Database. It maps the updated product to the product to be updated
        /// in the Database.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProductRepo(Product product)
        {
            EFProductManagementEntities pme = new EFProductManagementEntities();
            var productToBeUpdated = pme.Products.FirstOrDefault(x => x.ProductID == product.ProductID);

            if(productToBeUpdated != null)
            {
                Mapper.Map(product, productToBeUpdated);
                pme.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method returns a product by its product ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductByIdRepo(int id)
        {
            EFProductManagementEntities pme = new EFProductManagementEntities();
            return pme.Products.FirstOrDefault(x => x.ProductID == id);
        }

        /// <summary>
        /// This method deletes a product from the Database based on the product ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public bool DeleteProductRepo(int productID)
        {
            EFProductManagementEntities pme = new EFProductManagementEntities();
            var productToBeDeleted = pme.Products.Where(x => x.ProductID == productID).FirstOrDefault();

            if (productToBeDeleted != null)
            {
                pme.Products.Remove(productToBeDeleted);
                pme.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
