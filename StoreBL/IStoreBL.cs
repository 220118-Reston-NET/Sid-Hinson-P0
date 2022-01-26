using StoreModel;
namespace StoreBL
{
    /// <summary>
    /// BL - Manipulate / Validate/ Process DB data
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
    }

}

