using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_SRepository : ISQLStoreFrontsRepo
    {
        private readonly string _ConnectionStrings;
        public SQL_SRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }
        public StoreFronts AddStoreFronts(StoreFronts p_store)
        {

            string sqlQuery = @"insert into StoreFronts 
                                values (@StoreAddress, @StoreZipCode, @StoreState, @StoreCity)";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                                    
                con.Open();
                SqlCommand command =  new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreAddress", p_store.StoreAddress);
                command.Parameters.AddWithValue("@StoreZipCode", p_store.StoreZipCode);
                command.Parameters.AddWithValue("@StoreState", p_store.StoreState);
                command.Parameters.AddWithValue("@StoreCity", p_store.StoreCity);
                command.ExecuteNonQuery();
            }
            return p_store;
        }

        public List<StoreFronts> GetAllStoreFronts()
        {
            List<StoreFronts> listofstorefronts = new List<StoreFronts>();
            string sqlQuery =@"select * from StoreFronts";
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                con.Open();
                SqlCommand command = new SqlCommand(sqlQuery, con);
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    listofstorefronts.Add(new StoreFronts(){
                            StoreID = reader.GetInt32(1),
                            StoreAddress = reader.GetString(2),
                            StoreZipCode = reader.GetString(3),
                            StoreState = reader.GetString(4),
                            StoreCity = reader.GetString(5),
                    });
                }
            }
            return listofstorefronts;
        }
    }
}