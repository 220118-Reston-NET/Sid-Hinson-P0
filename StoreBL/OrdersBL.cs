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



        /// <summary>
        /// Add Order to Repo
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        public Orders AddOrders(Orders p_order)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            if(listoforders.Count < 25)
            {
                return _repo.AddOrders(p_order);
            }
            else
            {
                throw new Exception("Limit of 25 Orders is reached");
            }
        }



        /// <summary>
        /// Add Orders to Order History
        /// </summary>
        /// <param name="p_order"></param>
        /// <returns></returns>
        public Orders AddOrdersHistory(Orders p_order)
        {
            List<Orders> listoforders = _repo.GetAllOrders();
            return _repo.AddOrders(p_order);

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



        /// <summary>
        /// Add values to Item
        /// </summary>
        /// <param name="p_lineItem"></param>
        /// <returns></returns>
        public LineItems AddItem(int p_prodID, int p_prodStoreID, string p_prodName, double p_prodPrice, int p_prodQuant)
        {
            LineItems p_lineItem = new LineItems();
            p_lineItem.ProductID = p_prodID;
            p_lineItem.StoreID = p_prodStoreID;
            p_lineItem.ProductName = p_prodName;
            p_lineItem.ProductPrice = p_prodPrice;
            p_lineItem.ProductQuantity = p_prodQuant;

            return p_lineItem;
        }




        public List<LineItems> AddtoCart(List<LineItems> p_orderList, LineItems p_lineItem)
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
                Console.WriteLine("Cart Contents:");
        } 

        public List<LineItems> DisplayCart(List<LineItems> p_List)
        {   
            foreach (LineItems item in p_List)
            {
                Console.WriteLine(item);

            }
            return p_List;
        }  
    }
}