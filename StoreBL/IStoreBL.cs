using StoreModel;
namespace StoreBL
{
    /// <summary>
    /// BL - Manipulate / Validate/ Process DB data
    /// Other types of Processing as Needed Here
    /// </summary>
    public interface IStoreBL
    {
        /// <summary>
        /// Adds Customer to DB passing a Customer obj
        /// Also Randomizes a OfferLottery 
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer p_cust);

        /// <summary>
        /// Will return List of objects related to Search query through p_name parameter
        /// </summary>
        /// <param name="p_name"></param>
        /// <returns>Filtered Search Results </returns>
        List<Customer> SearchCustomers(string p_name);

    }

}

