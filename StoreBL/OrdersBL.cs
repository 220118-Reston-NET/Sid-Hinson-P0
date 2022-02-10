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

        /// <summary>
        /// Add Order to Repo
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        public Orders AddOrders(Orders p_order)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            if(listoforders.Count < 500)
            {
                return _repo.AddOrders(p_order);
            }
            else
            {
                throw new Exception("Limit of 500 Orders is reached");
            }
        }

        /// <summary>
        /// Search All orders
        /// </summary>
        /// <param name="p_email"></param>
        /// <returns></returns>
        public List<Orders> SearchOrders(string p_email)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return listoforders
                    .Where(Orders => Orders.Equals(p_email))
                    .ToList(); //ToList method converts into return List collection
        }



        public LineItems AddLineItems(LineItems p_line)
        {
            List<LineItems> listoflineitems = _repo.GetAllLineItems();
            return _repo.AddLineItems(p_line);
        }
        /// <summary>
        /// Add values to Item
        /// </summary>
        /// <param name="p_lineItem"></param>
        /// <returns>LineItem</returns>
        public LineItems AddItemFields(int p_prodID, string p_orderID, int p_prodQuant)
        {
            LineItems p_lineItem = new LineItems();
            p_lineItem.ProductID = p_prodID;
            p_lineItem.ProductQuantity = p_prodQuant;
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