﻿using StoreModel;
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_fname"></param>
        /// <param name="p_lname"></param>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        List<Customers> SearchCustomers(string p_fname, string p_lname, string p_email, string p_pass);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_productCat"></param>
        /// <returns></returns>
        public List<Products> SearchProductsCat(string p_productCat);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_prodName"></param>
        /// <param name="p_prodComp"></param>
        /// <param name="p_StoreID"></param>
        /// <returns></returns>
        public List<Products> SearchProductsID(int p_productID);

        public double GetPrice(string p_prodName, string p_prodComp, int p_StoreID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_prodName"></param>
        /// <param name="p_prodComp"></param>
        /// <param name="p_StoreID"></param>
        /// <returns></returns>
        public int GetID(string p_prodName, string p_prodComp, int p_StoreID);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Products> GetAllProducts();
 
    }

    public interface IOrdersBL
    {
        /// <summary>
        /// Add Orders to Repo
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>order</returns>
        Orders AddOrders(Orders p_order);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetAllOrders();

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>Filtered Search Results </returns>
        // List<Orders> SearchOrders(string p_email);
        public List<Orders> SearchOrders(int p_custID, string p_status);


        //********Lineitems**********//

        /// <summary>
        /// Add Line Items to Repo
        /// </summary>
        /// <param name="p_line"></param>
        /// <returns>linetime</returns>
        public LineItems AddLineItems(LineItems p_line);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_prodID"></param>
        /// <param name="p_prodQuant"></param>
        /// <param name="p_storeID"></param>
        /// <param name="p_price"></param>
        /// <returns></returns>
        public LineItems AddItemFields(int p_prodID, int p_prodQuant, int p_storeID, double p_price);

        public List<LineItems> SearchLineItems(int p_orderID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_orderList"></param>
        /// <returns></returns>
        public List<LineItems> RemoveFromCart(List<LineItems> p_orderList);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_list"></param>
        /// <returns></returns>
        public List<LineItems> DisplayCart(List<LineItems> p_list);
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <param name="p_prodID"></param>
        /// <returns></returns>
        public Inventory FindItem(int p_storeID, int p_prodID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_inv"></param>
        /// <returns></returns>
        public Inventory UpdateInventory(Inventory p_inv);

    }
}

