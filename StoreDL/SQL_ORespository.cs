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
 
            string sqlQuery = @"insert into Customers 
                                values (@OrderID, @OrderCustID, @OrderStoreID, @OrderDate, @OrderTotal)";

            //2.MAP THESE VALUES into the sqlQuery string:
            // OrderID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
            // OrderCustID int FOREIGN KEY (OrderCustID) REFERENCES Customers (OrderID),
            // OrderStoreID int FOREIGN KEY (OrderStoreID) REFERENCES StoreFronts (StoreID),
            // OrderDate date,
            // OrderTotal decimal




            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                      

                con.Open();

 
                SqlCommand command =  new SqlCommand(sqlQuery, con);


                command.Parameters.AddWithValue("@OrderID", p_ord.OrderID);
                command.Parameters.AddWithValue("@OrderCustID", p_ord.OrderCustID);
                command.Parameters.AddWithValue("@OrderStoreID", p_ord.OrderStoreID);
                command.Parameters.AddWithValue("@OrderDate", p_ord.OrderDate);
                command.Parameters.AddWithValue("@OrderTotal", p_ord.OrderTotal);

 
                //EXECUTES THE SQL Statement
                command.ExecuteNonQuery();

            }

            return p_ord;
        }

        public List<Orders> GetAllOrders()
        {

            List<Orders> listoforders = new List<Orders>();


            string sqlQuery =@"select * from Customers";

             using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {

                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                

                SqlDataReader reader = command.ExecuteReader();


                while(reader.Read())
                {

                    listoforders.Add(new Orders(){
                            OrderID = reader.GetInt32(1),
                            OrderCustID = reader.GetInt32(2),
                            OrderStoreID = reader.GetInt32(3),
                            OrderDate = reader.GetString(4),
                            OrderTotal = reader.GetInt32(5),
                            });
                }
            }
            return listoforders;
        }
    }
}