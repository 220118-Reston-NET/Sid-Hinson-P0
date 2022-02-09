using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_InvRepository : ISQLInventoryRepo
    {

        private readonly string _ConnectionStrings;
        public SQL_InvRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }

        public Inventory AddInventory(Inventory p_inv)
        {
            
 
            string sqlQuery = @"insert into Inventory 
                                values (@StoreID, @ProductID, @ProductQuantity)";


            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {          
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreID", p_inv.StoreID);
                command.Parameters.AddWithValue("@ProductID", p_inv.ProductID);
                command.Parameters.AddWithValue("@ProductQuantity", p_inv.ProductQuantity);
                command.ExecuteNonQuery();
            }
            return p_inv;
        }
        public List<Inventory> GetAllInventory()
        {
            List<Inventory> listofinventory = new List<Inventory>();
            string sqlQuery =@"select * from Inventory";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {

                    listofinventory.Add(new Inventory(){
                            WarehouseID = reader.GetInt32(1),
                            StoreID = reader.GetInt32(2),
                            ProductID= reader.GetInt32(3),
                            ProductQuantity = reader.GetInt32(4),
                    });
                }
            }
            return listofinventory;
        }

        // public Inventory UpdateInventory(Inventory p_inv)
        // {

        // }
    }
}