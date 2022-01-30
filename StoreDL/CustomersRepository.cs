using Newtonsoft.Json.Linq;
using System.Text.Json;
using StoreModel;
namespace StoreDL
{
    /// <summary>
    /// Customers Repository CRUD
    /// </summary>
    public class CustomersRepository : ICustomersRepo
    {
        //Path to DB
        private string _filepath = "../StoreDL/DB/";
        private string _jsonString;
        /// <summary>
        /// Write Customers to DB
        /// </summary>
        /// <param name="p_cust"></param>
        /// <returns></returns>
        public Customers AddCustomer(Customers p_cust)
        {
            string path  = _filepath + "Customers.json";
            List<Customers> listofcustomer = GetAllCustomers();
            listofcustomer.Add(p_cust);
            _jsonString = JsonSerializer.Serialize(listofcustomer, new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText(path, _jsonString);
            return p_cust;
        }
        /// <summary>
        /// Grab Customers from DB
        /// </summary>
        /// <returns></returns>
        public List<Customers> GetAllCustomers()
        {
            _jsonString = File.ReadAllText(_filepath + "Customers.json");
            return JsonSerializer.Deserialize<List<Customers>>(_jsonString);
        }

    }
}