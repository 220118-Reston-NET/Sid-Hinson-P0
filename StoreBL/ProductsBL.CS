using StoreModel;
using StoreDL;

namespace StoreBL
{    public class ProductsBL : IProductsBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private ISQLProductsRepo _repo;
        public ProductsBL(ISQLProductsRepo p_repo)
        {
            _repo = p_repo;
        }
        public Products AddProducts(Products p_product)
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            if(listofproducts.Count < 20)
            {
                Console.WriteLine("Adding Product............");
                return _repo.AddProducts(p_product);
            }
            else
            {
                throw new Exception("Limit of 20 objects is reached");
            }
        }

        public List<Products> SearchProductsComp(string p_productComp) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCompany.Contains(p_productComp))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
        public List<Products> SearchProductsCat(string p_productCat) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCategory.Contains(p_productCat))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
        public List<Products> SearchProducts(string p_prodName, string p_prodComp, int p_StoreID)
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductName.Contains(p_prodName))//Filter a collection with a Lamda
                    .Where(Products => Products.ProductCompany.Contains(p_prodComp))//Filter a collection with a Lamda
                    .Where(Products => Products.StoreID.Equals(p_StoreID))//Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
        public double GetPrice(string p_prodName, string p_prodComp, int p_StoreID)
        {   
            double Price = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductName.Contains(p_prodName) & listofproducts[i].ProductCompany.Contains(p_prodComp) & listofproducts[i].StoreID.Equals(p_StoreID))
                {
                    Price = listofproducts[i].ProductPrice;
                    
                }

            }

            return Price;
        }
        public int GetID(string p_prodName, string p_prodComp, int p_StoreID)
        {   
            int StoreID = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductName.Contains(p_prodName) & listofproducts[i].ProductCompany.Contains(p_prodComp) & listofproducts[i].StoreID.Equals(p_StoreID))
                {
                    StoreID = listofproducts[i].StoreID;
                    
                }

            }

            return StoreID;
        }

        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts;
        }
    }
}