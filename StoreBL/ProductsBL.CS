using StoreModel;
using StoreDL;

namespace StoreBL
{    public class ProductsBL : IProductsBL
    {

        private ISQL_PRepository _repo;
        public ProductsBL(ISQL_PRepository p_repo)
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

        public List<Products> SearchProductsCat(string p_productCat, int p_storeID) 
        {
            Console.WriteLine("Searching for Product ...........");
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductCategory.Contains(p_productCat))//Filter a collection with a Lamda
                    .Where(Products => Products.StoreID.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }
        public List<Products> SearchProductsID(int p_productID)
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts
                    .Where(Products => Products.ProductID.Equals(p_productID))//Filter a collection with a Lamda
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
        public Products SearchForProduct(string p_productName, int p_productStoreID)
        {
            Products getprod = new Products();
            List<Products> listofproducts = _repo.GetAllProducts();
            foreach(Products prod in listofproducts)
            {
                if(prod.ProductName == p_productName & prod.StoreID == p_productStoreID)
                {
                    getprod = prod;
                }
            }
            return getprod;
        }
        public double GetPrice(int p_productID)
        {
            double Price = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductID.Equals(p_productID))
                {
                    Price = listofproducts[i].ProductPrice;
                }
            }
            return Price;
        }
        public int GetID(string p_prodName, string p_prodComp, int p_StoreID)
        {   
            int ProdID = 0;
            List<Products> listofproducts = _repo.GetAllProducts();
            for(int i = 0; i < listofproducts.Count; i++)
            {
                if(listofproducts[i].ProductName.Contains(p_prodName) & listofproducts[i].ProductCompany.Contains(p_prodComp) & listofproducts[i].StoreID.Equals(p_StoreID))
                {
                    ProdID = listofproducts[i].ProductID;    
                }
            }
            return ProdID;
        }
        public List<Products> GetAllProducts()
        {
            List<Products> listofproducts = _repo.GetAllProducts();
            return listofproducts;
        }
    }
}