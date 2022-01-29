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
        Customers AddCustomer(Customers p_custs);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns>Filtered Search Results </returns>
        List<Customers> SearchCustomers(string p_name1, string p_name2, string p_email);
        
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
        List<Products> SearchProducts(int p_productNumber);
        
    }

    public interface IOrdersBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        Orders AddOrders(Orders p_order);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns>Filtered Search Results </returns>
        List<Orders> SearchOrders(int p_order);
        
    }
}

