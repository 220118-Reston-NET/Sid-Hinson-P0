using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class MyStoreBL : IStoreBL
    {
        /// <summary>
        /// Dependency Injection - Code Usability
        /// Dependency Constructor
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
            
            //Validation Process; Uses IRepos Dependency
            List<Customer> listofcustomer = _repo.GetAllCustomers();
            if(listofcustomer.Count < 10)
            {
                return _repo.AddCustomer(p_cust);
            }
            else
            {
                throw new Exception("Limit of 10 objects is reached");
            }

        }
                //Search Function
        List<Customer> SearchCustomer(string p_name)
        {
        List<Customer> listOfCustomer = _repo.GetAllCustomers();
        }
    }
}