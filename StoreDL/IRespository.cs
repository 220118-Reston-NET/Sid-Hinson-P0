using StoreModel;

namespace StoreDL
{
    /// <summary>
    /// Data Layer Interface - DB - CRUD
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Add Customer to DB
        /// </summary>
        /// <param name="p_cust"></param> Customer Object
        /// <returns>Customer Added</returns>
        Customer AddCustomer(Customer p_cust);




    }    
}
