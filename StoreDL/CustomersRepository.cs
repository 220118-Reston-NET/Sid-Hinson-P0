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
            string _path = _filepath + "Customers.json";
            //Add an Unique ID at the time of Save
            p_cust.customerID = Guid.NewGuid().ToString();
            
            //Create file
            //Adds the Customer with Global Univeral ID Generated
            List<Customers> listofcustomers = GetAllCustomers();
            listofcustomers.Add(p_cust);
            _jsonString = JsonSerializer.Serialize(listofcustomers, new JsonSerializerOptions {WriteIndented = true});
            File.WriteAllText(_path, _jsonString);
            Console.WriteLine("New Customer was Saved to Database");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
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