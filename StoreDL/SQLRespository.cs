// using System.Data.SqlClient;
// using StoreModel;
// namespace StoreDL
// {
//     public class SQLRepository : ICustomersRepo
//     {

//         public Customers AddCustomer(Customers p_cust)
//         {
//             //Specify statement to do whatever operation based on method
//             string sqlquery = @"insert into Customer values(@CustomerName..........values......";

//             string sqlquery2 = $"insert into Customers ({obj.field}, {obj.field})";
//             //Automatically close resources, different than usual
//             //Using block lets us not have to use connection clsoe
//             using(SqlConnection con = new SqlConnection("Server=tcp:retrobarbariandb.database.windows.net,1433;Initial Catalog=RetroDB;Persist Security Info=False;User ID=RetroDBAdmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
//             {
//                 //Open Connection
//                 con.Open();

//                 //Add the Insert Values
//                 SqlCommand command = new SqlCommand(sqlquery, con);
//                 command.Parameters.AddWithValue("@CustomerValue");
//                 command.Parameters.AddWithValue("@CustomerValue");
//                 command.Parameters.AddWithValue("@CustomerValue");

//                 command.ExecuteNonQuery();     
//             }
//             return p_cust;
//         }


//         public List<Customers> GetAllCustomers()
//         {
//             List<Customers> listofcustomers = new List<Customers>();

//             string sqlQuery = @"selct * from Customers";

//             using (SqlConnection con = new SqlConnection("Server=tcp:retrobarbariandb.database.windows.net,1433;Initial Catalog=RetroDB;Persist Security Info=False;User ID=RetroDBAdmin;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
//             {
//                     //Open Connection
//                     con.Open();

//                     //Command Object that has sqlQuery and con object
//                     SqlCommand command = new SqlCommand(sqlQuery, con);
                    
//                     //Specialized in reading outputs that came from sql statement
//                     //Gives a SQL datareader object
//                     SqlDataReader reader = command.ExecuteReader();

//                     //Read Methods check if you have more rows to go through
//                     while(reader.Read())
//                     {
//                         //Map info into an object that c# understands
//                         listofcustomers.Add(new Customers(){
//                             //Zero Based Column Index
//                             //"Properties to Add, Name, ID,"
//                             CustomerID = reader.GetInt32(1) // It will get column CustomerID since it is very first column
//                             CustomerName = reader.GetString(2) // It will get second column which is name
//                             });
//                     }

//             }
//                     return listofcustomers;
//         }

//     }
// }