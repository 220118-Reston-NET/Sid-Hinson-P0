using System.Text.Json;
using StoreModel;
namespace StoreDL
{
    public class Repository : IRepository
    {
        //Filepath is to recognize Relative filepath from the entrypoint StoreUI
        private string _filepath = "../StoreDL/DB/";
        private string _jsonString;
        public Customer AddCustomer(Customer p_cust)
        {
            //Allows dev JSON file change on other methods
            string path  = _filepath + "Customer.json";
            List<Customer> listofcustomer = GetAllCustomers();
            listofcustomer.Add(p_cust);
            
            //Serialize the Customer Object
            _jsonString = JsonSerializer.Serialize(p_cust, new JsonSerializerOptions {WriteIndented = true});
            //Write the Object
            File.WriteAllText(path, _jsonString);

            //Return Parameter as that is what it is set to be
            return p_cust;
        }

        public List<Customer> GetAllCustomers()
        {
            //Grab Information from Path
            _jsonString = File.ReadAllText(_filepath + "Customer.json");
            //Convert JSON objs string 
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
            
        }
    }
}