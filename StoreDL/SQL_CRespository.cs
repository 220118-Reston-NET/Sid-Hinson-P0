using System.Data.SqlClient;
using StoreModel;
namespace StoreDL
{
    public class SQL_CRepository : ISQL_CRepository
    {

        //7.Privatizing the Connection String as a PARAMETER
        //This Method makes it DYNAMICALLY CHANGE
        //So now it will require a STRING of the connection to CREATE OBJ out of it
        private readonly string _ConnectionStrings;
        public SQL_CRepository(string p_ConnectionStrings)
        {
            _ConnectionStrings = p_ConnectionStrings;
        }
        //8.Afterwards we go to/CREATE appsettings.json in the UI CLass, which is what configures the app
        //We ignore the appsettings.json file. in .gitignore
        //we set a connection string with a name KEY in the "ConnectionsStrings" configuration call of the appsettings.json
        //We need to go to Program.cs (where creation logic of repo is called) and READ and OBTAIN connectionstring
        //9. To do this we need to add : dotnet add package Microsoft.Extensions.Configuration --version 6.0.2-mauipre.1.22054.8 (or latest)
        //We need to put this in the right project, in this case StoreUI. if dont correctly, it will appear in .csproj
        //10. To manipulate the actual JSON, we need to download that specfic package too. Microsoft.Extensions.Configuration.Json (or latest)
        //We add this as well to , to the StoreUI
        //11. In ADDITON if we need to add the Extensions Package that allows for FileExtensions configuration which is ^ "..Configuration.FileExtensions" (latest)
        //12. We go the program.cs in UI and add the code to do the above
        public Customers AddCustomers(Customers p_cust)
        {
            
            //1.Create a SQL Variable of How you Would Write the Query
            //@ BEFORE A STRING WILL IGNORE ALL SPECIAL CHARACTERS
            string sqlQuery = @"insert into Customers 
                                values (@CFirstName, @CLastName, @CDateofBirth, @CustomerAddress, @CustomerState, @CustomerCity, @CustomerZipCode, @CustCountry, @CustomerEmail, @CPassword)";

            //2.MAP THESE VALUES into the sqlQuery string:
            // CustomerID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
            // CFirstName varchar(50),
            // CLastName varchar(50),
            // CDateofBirth varchar(50),
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
            using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {                                     //7a. Here we ^ insert the private string, that is a 
                                                  // parameter given to CONSTRUCTOR for  DB locale
                //5.Open the DB Connection
                con.Open();

                //6.Another SQL CLASS : COMMAND CLASS --> Responsible for EXECUTING THE ACTUAL QUERY
                //sqlQuery goes here since this is the command you are aiming for and is the the proper use for the class
                //con goes here as well : This orders it to execute the command on that DB
                SqlCommand command =  new SqlCommand(sqlQuery, con);

                //7.Now it is time to pass in the parameters we defined earlier with the correct class values/fields
                //You are essentially mapping the Parameters with the value to insert

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
            //This operation will be bvery similar to the JSON one, with some caveats
            //1.CREATE the LIST OF CUSTOMERS
            List<Customers> listofcustomers = new List<Customers>();

            //2.CREATE the SQL Query string desired
            string sqlQuery =@"select * from Customers";

            //3.ESTABLISH the CONNECTION
             using(SqlConnection con = new SqlConnection(_ConnectionStrings))
            {
                //3.OPEN the CONNECTION
                con.Open();

                //4.CREATE the SQL Command
                SqlCommand command = new SqlCommand(sqlQuery, con);
                
                //5.The class used here is SQLReader which is designed to READ the TABLE of whatever command you have executed
                //C# only understands its classes and class libraries so this was created to do this for C# -> READ SQL statement TABLE OUTPUTS
                //READER will hold the FORM of the table that contains all the Customer Data
                //The EXECUTE READER also creates the READER
                SqlDataReader reader = command.ExecuteReader();

                //6. Here a WHILE LOOP is used to read the ROW
                //The Reader.READ method returns a bool; FALSE if NO ROW, True if ROW
                //This way, the WHILE LOOP will keep running until no more rows left in table
                while(reader.Read())
                {
                    //Here WE NEED TO MAP it to a class to get this to work
                    //Here we have a new list object, and we state each list property
                    //NOTE : Bases in SQL are ZERO BASED SO MAPPING for both starts at 0 [ ~ i.eCustomerID[0] = Column Customers.CustomerID[0]]
                    listofcustomers.Add(new Customers(){
                            CustomerID = reader.GetInt32(0),
                            CFirstName = reader.GetString(1),
                            CLastName = reader.GetString(2),
                            CDateofBirth = reader.GetString(3),
                            CustomerAddress = reader.GetString(4),
                            CustomerState = reader.GetString(5),
                            CustomerCity = reader.GetString(6),
                            CustomerZipcode = reader.GetString(7),
                            CustCountry = reader.GetString(8),
                            CustomerEmail = reader.GetString(9),
                            CPassword = reader.GetString(10)
                    });

                }
            }
            return listofcustomers;
        }
    }
}