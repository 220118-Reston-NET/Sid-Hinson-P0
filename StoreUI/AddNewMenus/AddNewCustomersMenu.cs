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
            Console.WriteLine("=       (Initial Values Are For Example)       =");
            Console.WriteLine("================================================");
            Console.WriteLine("=[0]  -  Return to Main Menu"); 
            Console.WriteLine("=[1]  -  First Name : " + _newCustomer.CFirstName); 
            Console.WriteLine("=[2]  -  Last Name : " + _newCustomer.CLastName); 
            Console.WriteLine("=[3]  -  Address : " + _newCustomer.CustomerAddress);
            Console.WriteLine("=[4]  -  City : " + _newCustomer.CustomerCity);        
            Console.WriteLine("=[5]  -  State : " + _newCustomer.CustomerState);
            Console.WriteLine("=[6]  -  Country : " + _newCustomer.CustCountry);
            Console.WriteLine("=[7]  -  Zipcode : " + _newCustomer.CustomerZipcode);
            Console.WriteLine("=[8]  -  Email : " + _newCustomer.CustomerEmail);
            Console.WriteLine("=[9]  -  Date Of Birth : " + _newCustomer.CDateofBirth);
            Console.WriteLine("=[10] - Password : " + _newCustomer.CPassword);
            Console.WriteLine("=[11] - Update & Save Information");
            Console.WriteLine("===============================================");
            Console.WriteLine("=(Press a Number to Enter Your Selected Info!)=");
            Console.WriteLine("===============================================");
        }
        
        public string UserSelection()
        {   Log.Information("User is inputting a selection");
            string userInput = Console.ReadLine();
            switch (userInput)
            {

                //Exit
                case "0":
                    Log.Information("User is exiting to Store Main Menu");
                    return "StoreMainMenu";


                //First Name Input
                case "1":
                    Log.Information("User is entering a First Name");
                    Console.WriteLine("Enter your First Name :");
                    _newCustomer.CFirstName = Console.ReadLine();
                    _newCustomer.CFirstName = _newCustomer.CFirstName.ToUpper();

                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newCustomer.CFirstName))
                    {
                        Console.WriteLine("Selection must have an input. Please retry.");
                        _newCustomer.CFirstName =Console.ReadLine();
                        _newCustomer.CFirstName = _newCustomer.CFirstName.ToUpper();

                    }
                    return "NewCustomersMenu";


                //Last Name Input
                case "2":
                    Log.Information("User is entering a Last Name");
                    Console.WriteLine("Enter your Last Name : ");
                    _newCustomer.CLastName = Console.ReadLine();
                    _newCustomer.CLastName = _newCustomer.CLastName.ToUpper();
 
                    //Testing for Null/Empty
                    while(string.IsNullOrEmpty(_newCustomer.CLastName))
                    {
                        Console.WriteLine("Selection must have an input. Please retry.");
                        _newCustomer.CLastName =Console.ReadLine();
                        _newCustomer.CLastName = _newCustomer.CLastName.ToUpper();

                    }
                    return "NewCustomersMenu";


                // Address Input
                case "3":
                    Log.Information("User is entering their Address");
                    Console.WriteLine("Enter your Address : ");
                    _newCustomer.CustomerAddress = Console.ReadLine();
                    _newCustomer.CustomerAddress = _newCustomer.CustomerAddress.ToUpper();

                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newCustomer.CustomerAddress))
                    {
                        Console.WriteLine("Selection must have an input. Please enter on next line : ");
                        _newCustomer.CustomerAddress = Console.ReadLine();
                        _newCustomer.CustomerAddress = _newCustomer.CustomerAddress.ToUpper();

                    }
                    return "NewCustomersMenu";


                // City Input
                case "4":
                    Log.Information("User is entering their City");
                    Console.WriteLine("Enter your City :");
                    _newCustomer.CustomerCity = Console.ReadLine();
                    _newCustomer.CustomerCity = _newCustomer.CustomerCity.ToUpper();

                    //Test for Null Or Empty
                    while(string.IsNullOrEmpty(_newCustomer.CustomerCity))
                    {
                        Console.WriteLine("Selection must have an input. Please enter on next line : ");
                        _newCustomer.CustomerCity = Console.ReadLine();
                        _newCustomer.CustomerCity = _newCustomer.CustomerCity.ToUpper();
                    }
                    return "NewCustomersMenu";


                // State Input
                case "5":
                    Log.Information("User is entering their State");
                    Console.WriteLine("Enter your State Abbreviation:");
                    _newCustomer.CustomerState = Console.ReadLine();
                    _newCustomer.CustomerState = _newCustomer.CustomerState.ToUpper();
                    bool isANumber = false;
                    //Test for Format
                    do
                    {
                        Console.WriteLine("Selection must have a valid input. Please enter on next line :");
                        _newCustomer.CustomerState = Console.ReadLine();
                        _newCustomer.CustomerState = _newCustomer.CustomerState.ToUpper();
                        string Test1 = _newCustomer.CustomerState;
                        isANumber = int.TryParse(Test1, out int x);
                        _newCustomer.CustomerState = Test1;
                        _newCustomer.CustomerState = _newCustomer.CustomerState.ToUpper();
                        while(isANumber == true)
                        {
                            Console.WriteLine("You Must Enter Alphabetical Characaters. Please enter on next line:");
                            string Retry = Console.ReadLine();
                            isANumber = int.TryParse(Retry, out int result);
                            _newCustomer.CustomerState = Retry;
                            _newCustomer.CustomerState = _newCustomer.CustomerState.ToUpper();
                        }

                    }while(string.IsNullOrEmpty(_newCustomer.CustomerState) || _newCustomer.CustomerState.Length > 2 || _newCustomer.CustomerState.Length < 2 || isANumber == true);
                    return "NewCustomersMenu";


                // Country Input
                case "6":
                    Log.Information("User is entering their Country");
                    Console.WriteLine("Enter your Country :");
                    _newCustomer.CustCountry = Console.ReadLine();
                    _newCustomer.CustCountry = _newCustomer.CustCountry.ToUpper();
                    //Test for Null/Empty
                    while(string.IsNullOrEmpty(_newCustomer.CustCountry))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                        _newCustomer.CustCountry = Console.ReadLine();
                        _newCustomer.CustCountry = _newCustomer.CustCountry.ToUpper();

                    }
                    return "NewCustomersMenu";


                // Zip Code Input
                case "7":
                    Log.Information("User is entering their Zipcode");
                    Console.WriteLine("Enter your Zipcode :");
                    _newCustomer.CustomerZipcode = Console.ReadLine();
                    bool isNumber = false;
                    //Test for Format
                    do
                    {
                       Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                       _newCustomer.CustomerZipcode = Console.ReadLine();
                       
                       string Test2 = _newCustomer.CustomerZipcode;
                       isNumber = int.TryParse(Test2, out int z);
                       while(isNumber == false)
                        {
                            Console.WriteLine("You Must Enter an 5 Digit Numerical ZipCode");
                            string Retry = Console.ReadLine();
                            isNumber = int.TryParse(Retry, out int result);
                            _newCustomer.CustomerZipcode = Convert.ToString(result);
                        }     
                    }
                    while(string.IsNullOrEmpty(_newCustomer.CustomerZipcode) || _newCustomer.CustomerState.Length != 5 ||  isNumber == false);        
                    return "NewCustomersMenu";


                // Email Input
                case "8":
                    Log.Information("User is entering their Email Address");
                    Console.WriteLine("Enter your Email Address :");
                    _newCustomer.CustomerEmail = Console.ReadLine();
                    _newCustomer.CustomerEmail = _newCustomer.CustomerEmail.ToUpper();
                    //Test for Null/Empty and @
                    while(string.IsNullOrEmpty(_newCustomer.CustomerEmail))
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                      _newCustomer.CustomerEmail = Console.ReadLine();
                      _newCustomer.CustomerEmail = _newCustomer.CustomerEmail.ToUpper();
                    }
                    if(_newCustomer.CustomerEmail.Contains("@"))
                    {
                        return "NewCustomersMenu";
                    }
                    else
                    {
                         Console.WriteLine("Selection must have a valid email. Resetting Email to Default value. Please enter again");
                         _newCustomer.CustomerEmail = "stephen.strange@aol.com";
                         _newCustomer.CustomerEmail = _newCustomer.CustomerEmail.ToUpper();
            
                    }
                    return "NewCustomersMenu";


                // Date of Birth Entry
                case "9":
                    Log.Information("User is entering their Date of Birth");
                    Console.WriteLine("Enter your Date of Birth");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.CDateofBirth = Console.ReadLine();
                    bool isNotALetter = false;
                    do
                    {
                        Console.WriteLine("Selection must have an input. Please Enter a Menu selection.");
                        _newCustomer.CDateofBirth = Console.ReadLine();
                        string Test3 = _newCustomer.CDateofBirth;
                        isNotALetter = int.TryParse(Test3, out int y);
                        while(isNotALetter == false)
                        {
                            Console.WriteLine("You Must Enter an 8 Digit Integer value in MMDDYYY format - Ex: 10211980 for Oct 21st 1980:");
                            string Retry = Console.ReadLine();
                            isNotALetter = int.TryParse(Retry, out int result);
                            _newCustomer.CDateofBirth = Convert.ToString(result);
                        }
                    }
                    while( string.IsNullOrEmpty(_newCustomer.CDateofBirth) || _newCustomer.CDateofBirth.Length > 8 || _newCustomer.CDateofBirth.Length < 8 || isNotALetter == false);
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

                //*************TODO: Validation check Method on all Inputs
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
                    Log.Information("User has made an Invalid Selection");
                    Console.WriteLine("You have made an Invalid Selection - Please Press Enter to Continue");
                    Console.ReadLine();
                    return "NewCustomersMenu";
            }
        }
    }
}