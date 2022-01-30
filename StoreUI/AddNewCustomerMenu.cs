using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class NewCustomerMenu : IMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static Customers _newCustomer = new Customers();
        //Dependency Injection
        private ICustomersBL _custBL;
        //
        public NewCustomerMenu(ICustomersBL p_custBL)
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
            Console.WriteLine("=[4] - Email : " + _newCustomer.Email);
            Console.WriteLine("=[5] - Phone Number : " + _newCustomer.phoneNumber);
            Console.WriteLine("=[5] - Date Of Birth : " + _newCustomer.phoneNumber);
            Console.WriteLine("=[6] - Update & Save Information");
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
                    return "AddCustomer";
                case "2":
                    Console.WriteLine("Enter a Last Name : ");
                    _newCustomer.lastName = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Enter an Address : ");
                    _newCustomer.customerAddress = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Enter an Email Address :");
                    _newCustomer.Email = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                    Console.WriteLine("Enter a Phone Number :");
                    _newCustomer.phoneNumber = Console.ReadLine();
                    return "AddCustomer";
                case "6":
                    Console.WriteLine("Enter a Date Of Birth : ########");
                    Console.WriteLine("Example : 10211980 for October 21st 1980");
                    _newCustomer.dateBirth = Console.ReadLine();
                    return "AddCustomer";
                case "7":
                    try
                    {   
                        _custBL.AddCustomer(_newCustomer);
                        Console.WriteLine("New Customer was Saved to Database");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();

                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Something Unexpected Happened");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                    default:
                    return "AddCustomer";
            }
        }
    }
}