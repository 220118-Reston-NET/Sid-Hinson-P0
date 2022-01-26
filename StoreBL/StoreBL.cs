using StoreModel;
using StoreDL;

namespace StoreBL
{
    //Changed name to MyStoreBL from StoreBL : Amiguity Error
    public class MyStoreBL : IStoreBL
    {
        /// <summary>
        /// Dependency Injection - Code Usability
        /// Interface - Field and Constructor
        /// </summary>
        private IRepository _repo;
        public MyStoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Customer AddCustomer(Customer p_cust)
        {
            //Randomize between Parameter Range
            Random Rand = new Random();
            p_cust.OfferLottery += Rand.Next(0,1000);
            
            return _repo.AddCustomer(p_cust);
        }
    }
}