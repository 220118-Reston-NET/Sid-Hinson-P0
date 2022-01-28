using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class MyStoreBL : IStoreBL
    {
        /// <summary>
        /// Dependency Constructor
        /// When we do this the _repo repos functions can now be called
        /// </summary>
        private IRepository _repo;
        public MyStoreBL(IRepository p_repo)
        {
            _repo = p_repo;
        }

        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns>_repor value parameter for AddCustomer</returns>
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
        
        //Search Function Property
        public List<Customer> SearchCustomers(string p_name)
        {
        //This Pulls all of the Customer Objects into the list to be filtered
        List<Customer> listofcustomer = _repo.GetAllCustomers();
        return listofcustomer
                    .Where(Customer => Customer.LastName.Contains(p_name)) //Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
    }
}