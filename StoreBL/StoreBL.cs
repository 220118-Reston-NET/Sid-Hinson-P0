using StoreModel;
using StoreDL;

namespace StoreBL
{
    //Changed name to MyStoreBL from StoreBL : Amiguity Error
    public class MyStoreBL : IStoreBL
    {
        /// <summary>
        /// Dependency Injection - Code Usability
        /// Interface - Field and **Dependency Constructor**, sets up MyStore to take a p_repo parameter
        /// </summary>
        private IRepository _repo;
        public MyStoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        public Customer AddCustomer(Customer p_cust)
        {
            //Randomize between Parameter Range
            Random Rand = new Random();
            p_cust.OfferLottery += Rand.Next(0,1000);
            
            return _repo.AddCustomer(p_cust);
        }
    }
}