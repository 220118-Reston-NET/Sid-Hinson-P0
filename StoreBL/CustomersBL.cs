using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class CustomersBL : ICustomersBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private ICustomersRepo _repo;
        public CustomersBL(ICustomersRepo p_repo)
        {
            _repo = p_repo;
        }
        /// <summary>
        /// Add Customer
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns> Returns _repo.AddCustomer the Passed Customer Obj</returns>
        public Customers AddCustomer(Customers p_cust)
        {
            List<Customers> listofcustomer = _repo.GetAllCustomers();
            if(listofcustomer.Count < 20)
            {
                return _repo.AddCustomer(p_cust);
            }
            else
            {
                throw new Exception("Limit of 20 Customers is reached");
            }

        }
        
        /// <summary>
        /// Search Function to Locate a Customer in the DB with userinput parameters
        /// </summary>
        /// <param name="p_fname"></param>
        /// <param name="p_lname"></param>
        /// <param name="p_email"></param>
        /// <returns></returns>
        public List<Customers> SearchCustomers(string p_fname, string p_lname, string p_email)
        {
        List<Customers> listofcustomer = _repo.GetAllCustomers();
        return listofcustomer
                    .Where(Customer => Customer.firstName.Contains(p_fname))
                    .Where(Customer => Customer.lastName.Contains(p_lname))
                    .Where(Customer => Customer.Email.Contains(p_email)) //Filter a collection with a Lamda
                    .ToList(); //ToList method converts into return List collection
        }
    }
}