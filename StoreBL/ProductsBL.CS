using StoreModel;
using StoreDL;

namespace StoreBL
{    public class ProductsBL : IProductsBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private IProductsRepo _repo;
        public ProductsBL(IProductsRepo p_repo)
        {
            _repo = p_repo;
        }
        public Products AddProducts(Products p_product)
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            if(listofproducts.Count < 20)
            {
                return _repo.AddProducts(p_product);
            }
            else
            {
                throw new Exception("Limit of 20 objects is reached");
            }
        }

        public List<Products> SearchProducts(string p_productName) 
        {
        List<Products> listofproducts = _repo.GetAllProducts();
        return listofproducts
                    .Where(Products => Products.Equals(p_productName))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
    }
}