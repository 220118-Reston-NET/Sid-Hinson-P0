using StoreModel;
namespace StoreBL
{
    /// <summary>
    /// BL - Manipulate / Validate/ Process DB data
    /// Contains Add Customer Method which excepts a customer
    /// </summary>
    public interface IStoreBL
    {
        /// <summary>
        /// Will add Customer Data to DB ; 
        /// Randomize OfferLottery Stat (Test)
        /// Limit DB size 5 (Test)
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        Customer AddCustomer(Customer p_cust);

        /// <summary>
        /// Give a List of Objects based on Search Field
        /// </summary>
        /// <param name="p_name"> Search Field </param>
        /// <returns></returns>
        // public List<Customer> SearchCustomers(string p_name)
        // {
        //     List<Customer> listofcustomers = _repo.GetAllCustomers();

        //     foreach (Customer x in listofcustomers)
        //     {
        //         if(x.LastName.Contains(p_name))
        //         {
        //             //Add to List
        //         }
        //     }
        // }
        // return Filtered List
    }

}

