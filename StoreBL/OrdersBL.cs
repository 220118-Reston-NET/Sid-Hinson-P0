using StoreModel;
using StoreDL;

namespace StoreBL
{
    public class OrdersBL : IOrdersBL
    {
        /// <summary>
        /// Dependency Injection Constructor
        /// </summary>

        // private IProductsBL _prod;
        private ISQLOrdersRepo _repo;
        public OrdersBL(ISQLOrdersRepo p_repo)
        {
            // _prod = p_prod;
            _repo = p_repo;
        }


        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders;
        }
        /// <summary>
        /// Add Order to Repo
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        public Orders AddOrders(Orders p_order)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            if(listoforders.Count < 1000)
            {
                return _repo.AddOrders(p_order);
            }
            else
            {
                throw new Exception("Limit of 1000 Orders is reached");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_storeID"></param>
        /// <param name="p_status"></param>
        /// <returns></returns>
        public List<Orders> SearchStoreOrders(int p_storeID, string p_status)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderStoreID.Equals(p_storeID))
                    .Where(Orders => Orders.OrderStatus.Contains(p_status))
                    .ToList(); //ToList method converts into return List collection
        }
        /// <summary>
        /// Search All orders
        /// </summary>
        /// <param name="p_email"></param>
        /// <returns></returns>
        public List<Orders> SearchOrders(int p_custID, string p_status)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderCustID.Equals(p_custID))
                    .Where(Orders => Orders.OrderStatus.Contains(p_status))
                    .ToList(); //ToList method converts into return List collection
        }
        public List<Orders> Search4Order(int p_custID, int p_storeID)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.OrderCustID.Equals(p_custID))
                    .Where(Orders => Orders.OrderStatus.Equals(p_storeID))
                    .ToList(); //ToList method converts into return List collection
        }

        public Orders SearchOrdStat(int p_ordID)
        {
            Orders foundord = new Orders();
            List<Orders> listoforders = _repo.GetAllOrders();
            foreach(Orders ord in listoforders)
            {
                if(ord.OrderID == p_ordID)
                {
                    return ord;
                }
                foundord = ord;
            }
            return foundord;
        }

        public void UpdateOrdStat(int p_ordID, string p_stat)
        {
            _repo.UpdateOrdStat(p_ordID, p_stat);
        }

        //******LineItems*******//

        public LineItems AddLineItems(LineItems p_line)
        {
            List<LineItems> listoflineitems = _repo.GetAllLineItems();
            return _repo.AddLineItems(p_line);
        }

        public List<LineItems> SearchLineItems(int p_orderID)
        {
            List<LineItems> listoflineitems = _repo.GetAllLineItems();
            return listoflineitems
                    .Where(LineItems => LineItems.OrderID.Equals(p_orderID))
                    .ToList(); //ToList method converts into return List collection
        }
        /// <summary>
        /// Add values to Item
        /// </summary>
        /// <param name="p_lineItem"></param>
        /// <returns>LineItem</returns>
        public LineItems AddItemFields(int p_prodID, int p_prodQuant,int p_storeID, double p_price)
        {
            LineItems p_lineItem = new LineItems();
            p_lineItem.ProductID = p_prodID;
            p_lineItem.ProductQuantity = p_prodQuant;
            p_lineItem.StoreID = p_storeID;
            p_lineItem.Price = p_price;
            return p_lineItem;
        }


        public List<LineItems> AddItemtoCart(List<LineItems> p_orderList, LineItems p_lineItem)
        {
                return p_orderList;
        }


        public List<LineItems> RemoveFromCart(List<LineItems> p_orderList)
        {
            return p_orderList;
        }

        public void DisplayGraphic()
        {
                Console.WriteLine("=========================================================="); 
                Console.WriteLine(")xxxxx[;;;;;;;;;>    )xxxxx[;;;;;;;;;>   )xxxxx[;;;;;;;;;>"); 
                Console.WriteLine("==========================================================");
        } 

        public List<LineItems> DisplayCart(List<LineItems> p_list)
        {   
            foreach (LineItems item in p_list)
            {
                Console.WriteLine(item);
            }
            return p_list;
        }  
    }
}