using PM_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_BLL
{
    public class ProductService
    {
        /// <summary>
        /// This method returns the list of products from the Database.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            ProductRepository pr = new ProductRepository();
            return pr.GetProductsRepo();
        }

        /// <summary>
        /// This method adds a product to the Database after validating the user input fields.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool AddProduct(Product product)
        {
            ProductRepository pr = new ProductRepository();

            // Check the inputs for validations
            if (ValidateInputs(product))
                return pr.AddProductRepo(product);

            return false;
        }

        /// <summary>
        /// This method checks if the user inputs are valid or not. It returns true if they are valid, and false otherwise.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool ValidateInputs(Product product)
        {
            // Performing validations
            if (
                string.IsNullOrEmpty(product.Name) ||
                string.IsNullOrEmpty(product.Description) ||
                product.Price == null || product.Price <= 0 ||
                product.Quantity == null || product.Quantity <= 0 ||
                string.IsNullOrEmpty(product.Category) ||
                string.IsNullOrEmpty(product.Supplier))
                return false;
            else
                return true;
        }

        /// <summary>
        /// This method updates a product to the Database after validating the user input fields.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool UpdateProduct(Product product) { 
            ProductRepository pr = new ProductRepository();

            // Check the inputs for validations
            if (ValidateInputs(product))
                return pr.UpdateProductRepo(product);

            return false;
        }

        /// <summary>
        /// This method returns the product based on product ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            ProductRepository pr = new ProductRepository();
            return pr.GetProductByIdRepo(id);
        }

        /// <summary>
        /// This method deletes a product from the Database based on the product ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public bool DeleteProduct(int productID)
        {
            ProductRepository pr = new ProductRepository();
            return pr.DeleteProductRepo(productID);
        }
    }
}
