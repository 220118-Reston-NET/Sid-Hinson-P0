using StoreModel;
using StoreDL;

namespace StoreBL
{

    public class CustomersBL : ICustomersBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private ISQLCustomersRepo _repo;
        public CustomersBL(ISQLCustomersRepo p_repo)
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
            Console.WriteLine("Adding Customer............");
            return _repo.AddCustomers(p_cust);
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
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .Where(Customers => Customers.CustomerEmail.Contains(p_email)) //Filter a collection with a Lambda
                    .ToList(); //ToList method converts into return List collection
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_fname"></param>
        /// <param name="p_lname"></param>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        public List<Customers> SearchCustomers(string p_fname, string p_lname, string p_email, string p_pass)
        {
        List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .Where(Customers => Customers.CustomerEmail.Contains(p_email))
                    .Where(Customers => Customers.CPassword.Contains(p_pass)) //Filter a collection with a Lambda
                    .ToList(); //ToList method converts into return List collection
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_fname"></param>
        /// <param name="p_lname"></param>
        /// <param name="p_city"></param>
        /// <param name="p_state"></param>
        /// <returns></returns>
        public List<Customers> Search4Customers(string p_fname, string p_lname, string p_city, string p_state)
        {
                    List<Customers> listofcustomers = _repo.GetAllCustomers();
        return listofcustomers
                    .Where(Customers => Customers.CFirstName.Contains(p_fname))
                    .Where(Customers => Customers.CLastName.Contains(p_lname))
                    .Where(Customers => Customers.CustomerCity.Contains(p_city))
                    .Where(Customers => Customers.CustomerState.Contains(p_state))
                     //Filter a collection with a Lambda
                    .ToList(); //ToList method converts into return List collection
        }


        /// <summary>
        /// Grabs Customer ID from Email and Password
        /// </summary>
        /// <param name="p_email"></param>
        /// <param name="p_pass"></param>
        /// <returns></returns>
        public int GetID(string p_email, string p_pass)
        {   
            int CustomerID = 0;
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            for(int i = 0; i < listofcustomers.Count; i++)
            {
                if(listofcustomers[i].CustomerEmail.Contains(p_email) & listofcustomers[i].CPassword.Contains(p_pass))
                {
                    CustomerID = listofcustomers[i].CustomerID;    
                }
            }
            return CustomerID;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetAllCustomers()
        {
            List<Customers> listofcustomers = _repo.GetAllCustomers();
            return listofcustomers;
        }
    }
}