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
            string? userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "StoreMainMenu";
                case "1":
                    Console.WriteLine("Enter a First Name :");
                    _newCustomer.CFirstName = Console.ReadLine();
                    return "NewCustomersMenu";
                case "2":
                    Console.WriteLine("Enter a Last Name : ");
                    _newCustomer.CLastName = Console.ReadLine();
                    return "NewCustomersMenu";
                case "3":
                    Console.WriteLine("Enter an Address : ");
                    _newCustomer.CustomerAddress = Console.ReadLine();
                    return "NewCustomersMenu";
                case "4":
                    Console.WriteLine("Enter a City :");
                    _newCustomer.CustomerCity = Console.ReadLine();
                    return "NewCustomersMenu";
                case "5":
                    Console.WriteLine("Enter a State :");
                    _newCustomer.CustomerState = Console.ReadLine();
                    return "NewCustomersMenu";
                case "6":
                    Console.WriteLine("Enter a USA :");
                    _newCustomer.CustCountry = Console.ReadLine();
                    return "NewCustomersMenu";               
                case "7":
                    Console.WriteLine("Enter a Zipcode :");
                    _newCustomer.CustomerZipcode = Console.ReadLine();
                    return "NewCustomersMenu";
                case "8":
                    Console.WriteLine("Enter an Email Address :");
                    _newCustomer.CustomerEmail = Console.ReadLine();
                    return "NewCustomersMenu";
                case "9":
                    Console.WriteLine("Enter a Date of Birth");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.CDateofBirth = Console.ReadLine();
                    return "NewCustomersMenu";
                case "10":
                    Console.WriteLine("Enter a Password");
                    _newCustomer.CPassword = Console.ReadLine();
                    return "NewCustomersMenu";       
                case "11":
                    try
                    {   
                        _custBL.AddCustomers(_newCustomer);

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "NewCustomersMenu";
                    default:
                    return "NewCustomersMenu";
            }
        }
    }
}