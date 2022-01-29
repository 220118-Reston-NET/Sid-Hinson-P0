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

        public List<Orders> SearchOrders(int p_orderNumber)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.Equals(p_orderNumber))
                    .ToList(); //ToList method converts into return List collection
        }
    }
}