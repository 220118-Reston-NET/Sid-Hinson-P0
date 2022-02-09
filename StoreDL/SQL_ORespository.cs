using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_ORepository : ISQLOrdersRepo
    {


        private readonly string _ConnectionStrings;
        public SQL_ORepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }

        public Orders AddOrders(Orders p_ord)
        {
            string sqlQuery = @"insert into Orders 
                                values (@OrderID, @OrderCustID, @OrderStoreID, @OrderDate, @OrderTotal, @OrderStatus)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);

                command.Parameters.AddWithValue("@OrderID", p_ord.OrderID);
                command.Parameters.AddWithValue("@OrderCustID", p_ord.OrderCustID);
                command.Parameters.AddWithValue("@OrderStoreID", p_ord.OrderStoreID);
                command.Parameters.AddWithValue("@OrderDate", p_ord.OrderDate);
                command.Parameters.AddWithValue("@OrderTotal", p_ord.OrderTotal);
                command.Parameters.AddWithValue("@OrderStatus", p_ord.OrderStatus);
 
                //EXECUTES THE SQL Statement
                command.ExecuteNonQuery();

            }
            return p_ord;
        }

        public LineItems AddLineItems(LineItems p_line)
        {
            string sqlQuery = @"insert into LineItems 
                                values (@OrderID, @ProductID, @ProductQuantity)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@OrderID", p_line.OrderID);
                command.Parameters.AddWithValue("@ProductID",p_line.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity",p_line.ProductQuantity);
                command.ExecuteNonQuery();

            }
            return p_line;
        }

        public List<Orders> GetAllOrders()
        {
            List<Orders> listoforders = new List<Orders>();
            string sqlQuery =@"select * from Orders";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {

                        listoforders.Add(new Orders(){
                                OrderID = reader.GetString(1),
                                OrderCustID = reader.GetInt32(2),
                                OrderStoreID = reader.GetInt32(3),
                                OrderDate = reader.GetString(4),
                                OrderTotal = reader.GetInt32(5),
                                OrderStatus = reader.GetString(6)
                                });
                    }
            }
            return listoforders;
        }

        public List<LineItems> GetAllLineItems()
        {
            List<LineItems> listoflineitems = new List<LineItems>();
            string sqlQuery =@"select * from LineItems";

                using(SqlConnection con = new SqlConnection(_ConnectionStrings))
                {

                    con.Open();
                    SqlCommand command = new SqlCommand(sqlQuery, con);
                    SqlDataReader reader = command.ExecuteReader();


                    while(reader.Read())
                    {

                        listoflineitems.Add(new LineItems(){
                                OrderID = reader.GetString(1),
                                ProductID = reader.GetInt32(2),
                                ProductQuantity = reader.GetInt32(3),

                                });
                    }
                }
            return listoflineitems;
        }  
    }
}

