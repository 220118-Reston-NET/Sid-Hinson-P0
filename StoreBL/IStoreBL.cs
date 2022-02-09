using StoreModel;
namespace StoreBL
{
    /// <summary>
    /// BL - Manipulate / Validate/ Process DB data
    /// Other types of Processing as Needed Here
    /// </summary>
    public interface ICustomersBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_custs"></param>
        /// <returns></returns>
        Customers AddCustomers(Customers p_custs);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns>Filtered Search Results </returns>
        List<Customers> SearchCustomers(string p_name1, string p_name2, string p_email);
        List<Customers> SearchCustomers(string p_fname, string p_lname, string p_email, string p_pass);
        public int GetID(string p_email, string p_pass);


    }
    public interface IStoreFrontsBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_sfront"></param>
        /// <returns></returns>
        StoreFronts AddStoreFronts(StoreFronts p_sfront);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_storeNumber"></param>
        /// <returns>Filtered Search Results </returns>
        List<StoreFronts> SearchStoreFronts(int p_storeNumber);
        
    }

    public interface IProductsBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_product"></param>
        /// <returns></returns>
        Products AddProducts(Products p_product);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_productNumber"></param>
        /// <returns>Filtered Search Results </returns>
        List<Products> SearchProducts(string p_productName, string p_productComp, int p_productStoreID);
        // List<Products> SearchProductsCat(string p_productCat);
        // List<Products> SearchProductsComp(string p_productComp);
        public List<Products> SearchProductsComp(string p_productComp);
        public List<Products> SearchProductsCat(string p_productCat);
        public double GetPrice(string p_prodName, string p_prodComp, int p_StoreID);
        public int GetID(string p_prodName, string p_prodComp, int p_StoreID);

        public List<Products> GetAllProducts();
 
    }

    public interface IOrdersBL
    {
        /// <summary>
        /// Add Line Items to Repo
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns>linetime</returns>
        public LineItems AddLineItems(LineItems p_line);
        /// <summary>
        /// Add Orders to Repo
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>order</returns>
        Orders AddOrders(Orders p_order);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>Filtered Search Results </returns>
        // List<Orders> SearchOrders(string p_email);
        public List<Orders> SearchOrders(string p_email);
        public LineItems AddItem(int p_prodID, string p_orderID, int p_prodQuant);
        public List<LineItems> RemoveFromCart(List<LineItems> p_orderList);

        public List<LineItems> DisplayCart(List<LineItems> p_list);
        public void DisplayGraphic();

    }

        public interface IInventoryBL
    {
        /// <summary>
        /// Adds Inventory to DB passing a Inventory obj
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        public Inventory AddInventory(Inventory p_inv);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_storeNumber"></param>
        /// <returns>Filtered Search Results </returns>
        public List<Inventory> SearchInventory(int p_storeID, int p_prodID);
        public Inventory FindItem(int p_storeID, int p_prodID);
    }
}

