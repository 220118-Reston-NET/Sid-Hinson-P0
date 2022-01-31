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
            Console.WriteLine("=[1] - First Name : " + _newCustomer.firstName); 
            Console.WriteLine("=[2] - Last Name : " + _newCustomer.lastName); 
            Console.WriteLine("=[3] - Address : " + _newCustomer.customerAddress);
            Console.WriteLine("=[4] - City : " + _newCustomer.customerCity);        
            Console.WriteLine("=[5] - State : " + _newCustomer.customerState);
            Console.WriteLine("=[6] - Zipcode : " + _newCustomer.customerZipcode);
            Console.WriteLine("=[7] - Email : " + _newCustomer.Email);
            Console.WriteLine("=[8] - Date Of Birth : " + _newCustomer.dateBirth);
            Console.WriteLine("=[9] - Password : " + _newCustomer.password);
            Console.WriteLine("=[10] - Update & Save Information");
            Console.WriteLine("===============================================");
        }
        
        public string UserSelection()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Enter a First Name :");
                    _newCustomer.firstName = Console.ReadLine();
                    return "NewCustomersMenu";
                case "2":
                    Console.WriteLine("Enter a Last Name : ");
                    _newCustomer.lastName = Console.ReadLine();
                    return "NewCustomersMenu";
                case "3":
                    Console.WriteLine("Enter an Address : ");
                    _newCustomer.customerAddress = Console.ReadLine();
                    return "NewCustomersMenu";
                case "4":
                    Console.WriteLine("Enter a City :");
                    _newCustomer.customerCity = Console.ReadLine();
                    return "NewCustomersMenu";
                case "5":
                    Console.WriteLine("Enter a State :");
                    _newCustomer.customerState = Console.ReadLine();
                    return "NewCustomersMenu";
                case "6":
                    Console.WriteLine("Enter a Zipcode :");
                    _newCustomer.customerZipcode = Console.ReadLine();
                    return "NewCustomersMenu";
                case "7":
                    Console.WriteLine("Enter an Email Address :");
                    _newCustomer.Email = Console.ReadLine();
                    return "NewCustomersMenu";
                case "8":
                    Console.WriteLine("Enter a Date of Birth");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.dateBirth = Console.ReadLine();
                    return "NewCustomersMenu";
                case "9":
                    Console.WriteLine("Enter a Password");
                    _newCustomer.password = Console.ReadLine();
                    return "NewCustomersMenu";       
                case "10":
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
                    return "CustomersMenu";
                    default:
                    return "NewCustomersMenu";
            }
        }
    }
}