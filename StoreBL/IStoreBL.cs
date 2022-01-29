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
        /// <param name="p_cust"></param>
        /// <returns></returns>
        Customers AddCustomer(Customers p_cust);

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
        /// <param name="p_cust"></param>
        /// <returns></returns>
        StoreFronts AddStoreFronts(StoreFronts p_sfronts);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns>Filtered Search Results </returns>
        List<StoreFronts> SearchStoreFronts(int p_storeNumber);
        
    }


}

