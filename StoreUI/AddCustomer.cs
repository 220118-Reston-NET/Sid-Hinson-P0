using StoreModel;
using StoreBL;
namespace StoreUI
{
    public class AddCustomer : IStoreMenu
    {
        //Static Class for variable Consistently Across the Created Class Objects
        private static Customer _newcustomer = new Customer();
        //Dependency Injection
        private IStoreBL _custBL;
        //
        public AddCustomer(IStoreBL p_custBL)
        {
            _custBL = p_custBL;
        }
        public void MenuDisplay()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("=             Menu : Add Customer              =");
            Console.WriteLine("===============================================");
            Console.WriteLine("=         Enter Customer Info : Select         =");     
            Console.WriteLine("================================================");
            Console.WriteLine("=[0] - Return to Main Menu");
            Console.WriteLine("=[1] - First Name : " + _newcustomer.FirstName); 
            Console.WriteLine("=[2] - Last Name : " + _newcustomer.LastName); 
            Console.WriteLine("=[3] - Enter Address : " + _newcustomer.Address);
            Console.WriteLine("=[4] - Enter Email : " + _newcustomer.Email);
            Console.WriteLine("=[5] - Update & Save Information");
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
                    _newcustomer.FirstName = Console.ReadLine();
                    return "AddCustomer";
                case "2":
                    Console.WriteLine("Enter a Last Name : ");
                    _newcustomer.LastName = Console.ReadLine();
                    return "AddCustomer";
                case "3":
                    Console.WriteLine("Enter an Address : ");
                    _newcustomer.Address = Console.ReadLine();
                    return "AddCustomer";
                case "4":
                    Console.WriteLine("Enter an Email Address :");
                    _newcustomer.Email = Console.ReadLine();
                    return "AddCustomer";
                case "5":
                    try
                    {
                        _custBL.AddCustomer(_newcustomer);
                    }
                    catch (System.Exception exc)
                    {
                        Console.WriteLine(exc.Message);
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