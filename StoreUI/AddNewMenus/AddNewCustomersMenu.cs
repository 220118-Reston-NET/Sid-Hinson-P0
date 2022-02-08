using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomersMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static Customers _newCustomer = new Customers();
        //Dependency Injection
        private ICustomersBL _custBL;
        //
        public NewCustomersMenu(ICustomersBL p_custBL)
        {
            _custBL = p_custBL;
        }


        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Customer              =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=       Enter New Customer Info : Select       =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu"); 
            Console.WriteLine("=[1] - First Name : " + _newCustomer.CFirstName); 
            Console.WriteLine("=[2] - Last Name : " + _newCustomer.CLastName); 
            Console.WriteLine("=[3] - Address : " + _newCustomer.CustomerAddress);
            Console.WriteLine("=[4] - City : " + _newCustomer.CustomerCity);        
            Console.WriteLine("=[5] - State : " + _newCustomer.CustomerState);
            Console.WriteLine("=[6] - Country : " + _newCustomer.CustCountry);
            Console.WriteLine("=[7] - Zipcode : " + _newCustomer.CustomerZipcode);
            Console.WriteLine("=[8] - Email : " + _newCustomer.CustomerEmail);
            Console.WriteLine("=[9] - Date Of Birth : " + _newCustomer.CDateofBirth);
            Console.WriteLine("=[10] - Password : " + _newCustomer.CPassword);
            Console.WriteLine("=[11] - Update & Save Information");
            Console.WriteLine("===============================================");
        }
        
        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Log.Information("User is exiting to Store Main Menu");
                    return "StoreMainMenu";


                case "1":
                    Log.Information("User is entering a First Name");
                    Console.WriteLine("Enter your First Name :");
                    _newCustomer.CFirstName = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CFirstName))
                    {
                        Console.WriteLine("Selection must have an input. Please retry.");
                        _newCustomer.CFirstName =Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "2":
                    Log.Information("User is entering a Last Name");
                    Console.WriteLine("Enter your Last Name : ");
                    _newCustomer.CLastName = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CLastName))
                    {
                        Console.WriteLine("Selection must have an input. Please retry.");
                       _newCustomer.CLastName =Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "3":
                    Log.Information("User is entering their Address");
                    Console.WriteLine("Enter your Address : ");
                    _newCustomer.CustomerAddress = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustomerAddress))
                    {
                        Console.WriteLine("Selection must have an input. Please retry.");
                       _newCustomer.CustomerAddress = Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "4":
                    Log.Information("User is entering their City");
                    Console.WriteLine("Enter your City :");
                    _newCustomer.CustomerCity = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustomerCity))
                    {
                        Console.WriteLine("Selection must have an input. Please enter on next line : ");
                       _newCustomer.CustomerCity = Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "5":
                    Log.Information("User is entering their State");
                    Console.WriteLine("Enter your State Abbreviation:");
                    _newCustomer.CustomerState = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustomerState))
                    {
                        Console.WriteLine("Selection must have a valid input. Please enter on next line :");
                      _newCustomer.CustomerState = Console.ReadLine();
                    }
                    while(_newCustomer.CustomerState.Length != 2)
                    {
                        Console.WriteLine("Selection must have a valid 2 Letter State Abbreviation . Please enter on next line :");
                      _newCustomer.CustomerState = Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "6":
                    Log.Information("User is entering their Country");
                    Console.WriteLine("Enter your Country :");
                    _newCustomer.CustCountry = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustCountry))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CustCountry = Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                case "7":
                    Log.Information("User is entering their Zipcode");
                    Console.WriteLine("Enter your Zipcode :");
                    _newCustomer.CustomerZipcode = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustomerZipcode))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CustomerZipcode = Console.ReadLine();
                    }
                    while(_newCustomer.CustomerState.Length < 5)
                    {
                        Console.WriteLine("Selection must have a valid 5 Number Zipcode . Please enter on next line :");
                      _newCustomer.CustomerState = Console.ReadLine();
                    }              
                    return "NewCustomersMenu";


                case "8":
                    Log.Information("User is entering their Email Address");
                    Console.WriteLine("Enter your Email Address :");
                    _newCustomer.CustomerEmail = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CustomerEmail))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CustomerEmail = Console.ReadLine();
                    }
                    if(_newCustomer.CustomerEmail.Contains("@"))
                    {
                        return "NewCustomersMenu";
                    }
                    else
                    {
                         Console.WriteLine("Selection must have a valid email. Resetting Email to Null. Please  enter again");
                         _newCustomer.CustomerEmail = "";
            
                    }
                    return "NewCustomersMenu";


                case "9":
                    Log.Information("User is entering their Date of Birth");
                    Console.WriteLine("Enter your Date of Birth");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.CDateofBirth = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CDateofBirth))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CDateofBirth = Console.ReadLine();
                      return "NewCustomersMenu";
                    }  
                    return "NewCustomersMenu";


                case "10":
                    Log.Information("User is entering their Password");
                    Console.WriteLine("Enter your Password");
                    _newCustomer.CPassword = Console.ReadLine();
                    while(string.IsNullOrEmpty(_newCustomer.CPassword))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CPassword = Console.ReadLine();
                      return "NewCustomersMenu";
                    }  
                    return "NewCustomersMenu";     


                case "11":
                    Log.Information("User is attempting to Save their Customer Information into the DB");
                    try
                    {   
                        _custBL.AddCustomers(_newCustomer);

                    }
                    catch (System.Exception exc)
                    {
                        Log.Information("User has attempted to save and the program has created an exception");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewCustomersMenu";


                    default:
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "NewCustomersMenu";
            }
        }
    }
}