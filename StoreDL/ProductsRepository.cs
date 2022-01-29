using System.Text.Json;
using StoreModel;
namespace StoreDL
{

    /// <summary>
    /// Products Repository CRUD
    /// </summary>
    public class ProductsRepository : IProductsRepo
    {
        private string _filepath = "../StoreDL/";
        private string _jsonString;
        /// <summary>
        /// Write Products to DB
        /// </summary>
        /// <param name="p_product"></param>
        /// <returns></returns>
        public Products AddProducts(Products p_product)
        {
            string path = _filepath + "Products.json";
            List<Products> listofproducts = GetAllProducts();
            listofproducts.Add(p_product);
            Console.WriteLine($"Saved {p_product} in Database");
            return p_product;
        }
        /// <summary>
        /// Grab Products from DB
        /// </summary>
        /// <returns></returns>
        public List<Products> GetAllProducts()
        {
            _jsonString = File.ReadAllText(_filepath + "Products.json");
            return JsonSerializer.Deserialize<List<Products>>(_jsonString);
        }


    }
}