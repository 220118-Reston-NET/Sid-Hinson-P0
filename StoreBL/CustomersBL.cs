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
        public Customers AddCustomers(Customers p_cust)
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();

            if(listofcustomers.Count < 20)
            {
                Console.WriteLine("Adding Customer............");
                return _repo.AddCustomers(p_cust);
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
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Equals(p_fname))
                    .Where(Customers => Customers.CLastName.Equals(p_lname))
                    .Where(Customers => Customers.CustomerEmail.Equals(p_email)) //Filter a collection with a Lambda
                    .ToList(); //ToList method converts into return List collection
        }

    }
}