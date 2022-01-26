using StoreModel;
namespace StoreDL
{
    public class Repository : IRepository
    {
        //Filepath is to recognize Relative filepath from the entrypoint StoreUI
        private string _filepath = "../StoreDL/DB";
        private string _jsonstring;
        public Customer AddCustomer(Customer p_cust)
        {
            //Allows dev JSON file change on other methods
            string path  = _filepath + "Customer.json";
            
            //Something is WRONG here
            _jsonstring = JsonSerializer.Serialize(p_cust);
        }
    }
}