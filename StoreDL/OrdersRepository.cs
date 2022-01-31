using System.Text.Json;
using StoreModel;
namespace StoreDL
{

    /// <summary>
    /// Orders Repository CRUD
    /// </summary>
    public class OrdersRepository : IOrdersRepo
    {
        private string _filepath = "../StoreDL/";
        private string _jsonString;
        /// <summary>
        /// Write Orders to DB
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        public Orders AddOrders(Orders p_order)
        {
            string path = _filepath + "Orders.json";
            List<Orders> listoforders = GetAllOrders();
            listoforders.Add(p_order);
            return p_order;
        }
        /// <summary>
        /// Grab Orders From DB
        /// </summary>
        /// <returns></returns>
        public List<Orders> GetAllOrders()
        {
            _jsonString = File.ReadAllText(_filepath + "Orders.json");
            return JsonSerializer.Deserialize<List<Orders>>(_jsonString);
        }


    }

}