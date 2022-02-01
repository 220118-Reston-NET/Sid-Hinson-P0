using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class OrdersBL : IOrdersBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>
        private IOrdersRepo _repo;
        public OrdersBL(IOrdersRepo p_repo)
        {
            _repo = p_repo;
        }
        public Orders AddOrders(Orders p_order)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            if(listoforders.Count < 20)
            {
                return _repo.AddOrders(p_order);
            }
            else
            {
                throw new Exception("Limit of 20 Orders is reached");
            }
        }

        public List<Orders> SearchOrders(string p_email)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.Equals(p_email))
                    .ToList(); //ToList method converts into return List collection
        }

        //May Need to make strings public in passing class
        // public List<Orders> GetUserID(string p_email, string p_password)
        // {
        //     List<Orders> listoforders = _repo.GetAllOrders();
        //     return listoforders
        //             .Where(Orders => Orders.Equals(p_email))
        //             .Where(Orders => Orders.Equals(p_password))
        //             .ToList();
        // }

    }
}