using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_CRepository : ISQLCustomersRepo


    {
        public Customers AddCustomers(Customers p_cust)
        {
            
            //1.Create a SQL Variable of How you Would Write the Query
            //@ BEFORE A STRING WILL IGNORE ALL SPECIAL CHARACTERS
            string sqlQuery = @"insert into Customers 
                                values (@CustomerID, @CFirstName, @CLastName, @CDateofBirth, @CustomerAddress, @CustomerState, @CustomerCity, @CustomerZipCode, @CustCountry, @CustomerEmail, @CPassword)";

            //2.MAP THESE VALUES:
            // CustomerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
            // CFirstName varchar(50),
            // CLastName varchar(50),
            // CDateofBirth date,
            // CustomerAddress varchar(50),
            // CustomerState varchar(50),
            // CustomerCity varchar(50),
            // CustomerZipcode varchar(50),
            // CustCountry varchar(50),
            // CustomerEmail varchar(50),
            // CPassword varchar(50)

            //3.INSTALL dotnet add package System.Data.SqlCient --version 4.8.3
            //This talks to SQL CLient ; you need to cd into the DL directory where the action is happening
            //You will see it in the CSPROJ

            //4."USING BLOCK" - This HELPS with Resource CLOSING like Open Connection i.e. optimization cpu resources
            //In the SQL CONNECTION NEW DECLARATION YOU NEED YOUR ADO.NET conn string or whatever server you are connecting to
            //If namespace not imported, you will get Compiler ERRORS
            using(SqlConnection con = new SqlConnection("Server=tcp:revature-retrodb.database.windows.net,1433;Initial Catalog=RetroBarbarianDB;Persist Security Info=False;User ID=RetroDBAdmin;Password=Skidrow345!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                //5.Open the DB Connection
                con.Open();

                //6.Another SQL CLASS : COMMAND CLASS --> Responsible for EXECUTING THE ACTUAL QUERY
                //sqlQuery goes here since this is the command you are aiming for and is the the proper use for the class
                //con goes here as well : This orders it to execute the command on that DB
                SqlCommand command =  new SqlCommand(sqlQuery, con);

                //7.Now it is time to pass in the parameters we defined earlier with the correct class values/fields
                //You are essentially mapping the Parameters with the value to insert
                command.Parameters.AddWithValue("@CustomerID", p_cust.CustomerID);
                command.Parameters.AddWithValue("@CFirstName", p_cust.CFirstName);
                command.Parameters.AddWithValue("@CLastName", p_cust.CLastName);
                command.Parameters.AddWithValue("@CDateofBirth", p_cust.CDateofBirth);
                command.Parameters.AddWithValue("@CustomerAddress", p_cust.CustomerAddress);
                command.Parameters.AddWithValue("@CustomerState", p_cust.CustomerState);
                command.Parameters.AddWithValue("@CustomerCity", p_cust.CustomerCity);
                command.Parameters.AddWithValue("@CustomerZipCode", p_cust.CustomerZipcode);
                command.Parameters.AddWithValue("@CustCountry", p_cust.CustCountry);
                command.Parameters.AddWithValue("@CustomerEmail",p_cust.CustomerEmail);
                command.Parameters.AddWithValue("@CPassword", p_cust.CPassword);
                //^This Method was introduced to combat SQL Injection Black Hat Hacking 

                //8.Last Step is to Execute the Query
                //EXECUTES THE SQL Statement
                command.ExecuteNonQuery();

            }

            return p_cust;
        }

        public List<Customers> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}